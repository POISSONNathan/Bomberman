using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    private gameManager _myGameManager;

    [SerializeField]
    private GameObject _soloModeUI;
    [SerializeField]
    private TextMeshProUGUI _textSoloMode;

    [SerializeField]
    private GameObject _multiModeUI;
    [SerializeField]
    private TextMeshProUGUI _textMultiMode;

    void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        if (_myGameManager.gameMode == "Solo")
        {
            _soloModeUI.SetActive(true);
            _multiModeUI.SetActive(false);

            if (_myGameManager.soloGameModeWin == true)
            {
                var endTime = Mathf.Round(_myGameManager.timeSoloMode - _myGameManager.endTimeSoloMode);
                _textSoloMode.text = "GG ! U won a " + _myGameManager.timeSoloMode + " second level in " + endTime + " seconds";
            }
            else
            {
                _textSoloMode.text = "Sadly u lose.. try to restart a nex game.";
            }
        }

        if (_myGameManager.gameMode == "Multi")
        {
            _soloModeUI.SetActive(false);
            _multiModeUI.SetActive(true);

            _textMultiMode.text = "GG " + _myGameManager.nameWinnerMulti + " ! U were better than your opponent !";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
