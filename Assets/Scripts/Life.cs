using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float _maxLife;

    public float _life;

    [SerializeField]
    private Image _progressBarLife;
    [SerializeField]
    private List<Image> _listGlobalLifeImage;

    private Vector2 _startPos;

    private int _globalLife;

    private gameManager _myGameManager;

    void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _startPos = transform.position;
        ResetLife();

        _globalLife = _listGlobalLifeImage.Count;   
        UpdateHeartUi(_listGlobalLifeImage.Count, false);
        UpdateHeartUi(_globalLife, true);
    }

    public void ResetLife()
    {
        _life = _maxLife;
        _progressBarLife.fillAmount = 1f;
    }

    public void AddLife(float ammountOfLifeChange)
    {
        _life += ammountOfLifeChange;
        _progressBarLife.fillAmount = _life / _maxLife;

        if (_life <= 0)
        {
            ResetLife();

            _globalLife -= 1;

            if (_globalLife <= 0)
            {
                if (this.gameObject.name == "Player1")
                {
                    _myGameManager.nameWinnerMulti = "Player 2 (the top right player)";
                }
                else
                {
                    _myGameManager.nameWinnerMulti = "Player 1 (the bottom left player)";
                }

                SceneManager.LoadScene("EndScene");
            }

            UpdateHeartUi(_listGlobalLifeImage.Count, false);
            UpdateHeartUi(_globalLife, true);

            transform.position = _startPos;
        }
    }

    private void UpdateHeartUi(int value,bool currentBool)
    {
        for (int i = 0; i < value; i++)
        {
            _listGlobalLifeImage[i].gameObject.SetActive(currentBool);
        }
    }

    public void DeacreaseLife(float ammountOfLifeChange)
    {
        AddLife(-ammountOfLifeChange);
    }
}
