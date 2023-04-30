using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public string gameMode;

    public int sizeWallX = 5;
    public int sizeWallY = 5;

    public int numberCaseInMap;

    public bool soloGameModeWin;

    public float timeSoloMode = 30;
    public float endTimeSoloMode;

    public string nameWinnerMulti;
    void Start()
    {
        numberCaseInMap = sizeWallX * sizeWallY;

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Menu");
    }
}
