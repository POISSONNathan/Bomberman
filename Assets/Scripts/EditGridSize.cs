using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditGridSize : MonoBehaviour
{
    private gameManager _myGameManager;

    [SerializeField]
    private TextMeshProUGUI _textToEdit;

    [SerializeField]
    private string _textXorY;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();

        switch (_textXorY)
        {
            case "X":
                _textToEdit.text = "X : " + _myGameManager.sizeWallX.ToString();
                break;
            case "Y":
                _textToEdit.text = "Y : " + _myGameManager.sizeWallY.ToString();
                break;
            default:
                break;
        }
    }

    public void addXValue()
    {
        _myGameManager.sizeWallX++;
        _textToEdit.text = "X : " + _myGameManager.sizeWallX.ToString();
    }
    public void removeXValue()
    {
        if (_myGameManager.sizeWallX > 5)
        {
            _myGameManager.sizeWallX--;
            _textToEdit.text = "X : " + _myGameManager.sizeWallX.ToString();
        }
    }

    public void addYValue()
    {
        _myGameManager.sizeWallY++;
        _textToEdit.text = "Y : " + _myGameManager.sizeWallY.ToString();
    }
    public void removeYValue()
    {
        if (_myGameManager.sizeWallY > 5)
        {
            _myGameManager.sizeWallY--;
            _textToEdit.text = "Y : " + _myGameManager.sizeWallY.ToString();
        }
    }
}
