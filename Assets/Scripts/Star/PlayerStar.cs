using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStar : MonoBehaviour
{
    public int numberStar;

    public float _numberStarMax;

    [SerializeField]
    private Text _textStar;

    private gameManager _myGameManager;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _numberStarMax = _myGameManager.timeSoloMode / 6;

        _textStar.text = numberStar.ToString() + "/" + _numberStarMax.ToString();
    }
    public void GetStar()
    {
        numberStar++;
        _textStar.text = numberStar.ToString() + "/" + _numberStarMax.ToString();

        if (numberStar >= _numberStarMax)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
