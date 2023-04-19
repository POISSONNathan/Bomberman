using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSoloMode : MonoBehaviour
{
    private gameManager _myGameManager;

    private float _timerSec;

    private float _timerMin;

    [SerializeField]
    private TextMeshProUGUI _timerUI;

    void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _timerMin = Mathf.Floor(_myGameManager.timeSoloMode / 60);

        _timerSec = _myGameManager.timeSoloMode % 60;
    }

    // Update is called once per frame
    void Update()
    {
        _timerSec -= Time.deltaTime;

        if (_timerSec > 10)
        {
            _timerUI.text = _timerMin.ToString() + " : " + _timerSec.ToString("F0");
        }
        else
        {
            _timerUI.text = _timerMin.ToString() + " : 0" + _timerSec.ToString("F0");
        }

        if (_timerSec <= 0)
        {
            _timerMin--;
            _timerSec = 60;
        }

        if (_timerMin < 0)
        { 
            SceneManager.LoadScene("Menu");
        }
    }
}
