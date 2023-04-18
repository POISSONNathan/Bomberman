using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartSoloScene13x9()
    {
        SceneManager.LoadScene("Solo_13x9");
    }

    public void StartMultiScene13x9()
    {
        SceneManager.LoadScene("Multi_13x9");
    }
}
