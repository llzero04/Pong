using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().playAudio("EndTheme");
    }

    public void loadHome()
    {
        SceneManager.LoadScene(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
