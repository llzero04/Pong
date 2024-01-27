using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().playAudio("HomeTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevelTwoPlayer()
    {
        PlayerPrefs.SetInt("GameMode", 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadLevelOnePlayer()
    {
        PlayerPrefs.SetInt("GameMode", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
