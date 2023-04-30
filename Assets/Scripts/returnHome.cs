using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnHome : MonoBehaviour
{
    public void ReturnHomeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
