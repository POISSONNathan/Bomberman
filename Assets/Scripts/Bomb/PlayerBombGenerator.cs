using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerBombGenerator : MonoBehaviour
{
    public GameObject bomb;

    private float _timerBomb;
    [SerializeField]
    private float _maxTimeUseBombAgain;

    [SerializeField]
    private float _forceAmountBomb;
    [SerializeField]
    private float _lifeSpanBomb;

    private float _startForceAmountBomb;
    private float _startLifeSpanBomb;

    private bool _canUseBomb = true;

    public Image barUseBomb;

    [SerializeField]
    private Image _imageBombPowerUp;

    [SerializeField]
    private Sprite _powerUpSpriteBomb;

    private Sprite _startSpriteBomb;

    public int numberBomb;

    [SerializeField]
    private Text _textNumberBomb;

    [SerializeField]
    private Grid _myGrid;

    private void Start()
    {
        _startForceAmountBomb = _forceAmountBomb;
        _startLifeSpanBomb = _lifeSpanBomb;

        _startSpriteBomb = _imageBombPowerUp.sprite;

        SetBomb(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canUseBomb)
        {
            CreateBomb(new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)));
            _canUseBomb = false;
            _timerBomb = 0;
        }

        if (_timerBomb <= _maxTimeUseBombAgain && !_canUseBomb)
        {
            _timerBomb += Time.deltaTime;
            float fillAmount = _timerBomb / _maxTimeUseBombAgain;
            barUseBomb.fillAmount = fillAmount;
        }
        else
        {
            _canUseBomb = true;
        }
    }

    public void InvokeBomb(InputAction.CallbackContext context)
    {
        if (context.action.triggered && _canUseBomb && numberBomb > 0)
        {
            CreateBomb(new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)));
            _canUseBomb = false;
            _timerBomb = 0;

            SetBomb(-1);
        }
    }

    public void SetBomb(int value)
    {
        numberBomb += value;
        _textNumberBomb.text = numberBomb.ToString();
    }

    public void CreateBomb(Vector2 position)
    {
        var newBomb = Instantiate(bomb, position, Quaternion.identity);

        _myGrid.allPositionOnMap.Remove(position);

        newBomb.GetComponent<Bomb>().lifeSpan = _lifeSpanBomb;
        newBomb.GetComponent<Bomb>().forceAmount = _forceAmountBomb;
    }

    public void GetPowerUpBomb(float Time)
    {
        _imageBombPowerUp.sprite = _powerUpSpriteBomb;

        _forceAmountBomb = _startForceAmountBomb * 2;
        _lifeSpanBomb = _startLifeSpanBomb / 2;
        Invoke("ResetVar", Time);
    }
    
    private void ResetVar()
    {
        _imageBombPowerUp.sprite = _startSpriteBomb;

        _forceAmountBomb = _startForceAmountBomb;
        _lifeSpanBomb = _startLifeSpanBomb;
    }
}
