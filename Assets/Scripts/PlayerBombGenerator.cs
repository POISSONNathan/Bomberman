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

    private void Start()
    {
        _startForceAmountBomb = _forceAmountBomb;
        _startLifeSpanBomb = _lifeSpanBomb;
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
        CreateBomb(new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)));
        _canUseBomb = false;
        _timerBomb = 0;
    }

    public void CreateBomb(Vector2 position)
    {
        var newBomb = Instantiate(bomb, position, Quaternion.identity);
        newBomb.GetComponent<Bomb>().lifeSpan = _lifeSpanBomb;
        newBomb.GetComponent<Bomb>().forceAmount = _forceAmountBomb;
    }

    public void GetPowerUpBomb(float Time)
    {
        _forceAmountBomb = _startForceAmountBomb * 2;
        _lifeSpanBomb = _startLifeSpanBomb * 2;
        Invoke("ResetVar", Time);
    }
    
    private void ResetVar()
    {
        _forceAmountBomb = _startForceAmountBomb;
        _lifeSpanBomb = _startLifeSpanBomb;
    }
}
