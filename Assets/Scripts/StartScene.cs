using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private gameManager _myGameManager;

    private void Start()
    {
        _myGameManager = FindObjectOfType<gameManager>();
    }

    public void StartSoloScene()
    {
        _myGameManager.gameMode = "Solo";
        SceneManager.LoadScene(_myGameManager.gameMode);
    }

    public void StartMultiScene()
    {
        _myGameManager.gameMode = "Multi";
        SceneManager.LoadScene(_myGameManager.gameMode);
    }
}
