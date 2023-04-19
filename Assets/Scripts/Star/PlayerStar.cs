using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStar : MonoBehaviour
{
    public int numberStar;

    private int _numberStarMax;

    [SerializeField]
    private Text _textStar;

    private gameManager _myGameManager;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();
    }
    public void GetStar()
    {
        numberStar++;
        _textStar.text = numberStar.ToString();

        if (numberStar >= _numberStarMax)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
