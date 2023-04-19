using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _myTextTime;

    private gameManager _myGameManager;
    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        _myTextTime.text = "Find many stars in " + _myGameManager.timeSoloMode + " seconds (30 sec)";
    }

    public void AddTime()
    {
        _myGameManager.timeSoloMode += 30;
        _myTextTime.text = "Find many stars in " + _myGameManager.timeSoloMode + " seconds (30 sec)";
    }

    public void RemoveTime()
    {
        if (_myGameManager.timeSoloMode > 30)
        {
            _myGameManager.timeSoloMode -= 30;
            _myTextTime.text = "Find many stars in " + _myGameManager.timeSoloMode + " seconds (30 sec)";
        }
    }
}
