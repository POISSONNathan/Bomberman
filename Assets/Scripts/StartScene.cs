using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private void StartSoloScene()
    {
        SceneManager.LoadScene("Solo");
    }

    private void StartMultiScene()
    {
        SceneManager.LoadScene("Multi");
    }
}
