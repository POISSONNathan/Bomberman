using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _myTextTime;

    private gameManager _myGameManager;

    private int numberStar;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        numberStar = 5;
        _myTextTime.text = "Find " + numberStar + " stars in " + _myGameManager.timeSoloMode + " seconds (30 sec minimum)";
    }

    public void AddTime()
    {
        _myGameManager.timeSoloMode += 30;
        numberStar += 5;
        _myTextTime.text = "Find " + numberStar + " stars in " + _myGameManager.timeSoloMode + " seconds (30 sec minimum)";
    }

    public void RemoveTime()
    {
        if (_myGameManager.timeSoloMode > 30)
        {
            _myGameManager.timeSoloMode -= 30;
            numberStar -= 5;
            _myTextTime.text = "Find " + numberStar + " stars in " + _myGameManager.timeSoloMode + " seconds (30 sec minimum)";
        }
    }
}
