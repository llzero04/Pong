using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject spawnCounterObject;
    public Text scoreText;
    // public Text SpawnTimerText;
    public GameObject playerRed;
    public GameObject playerBlue;
    public GameObject gameOverPanel;
    public Text matchResultText;

    int playerRedScore = 0;
    int playerBlueScore = 0;

    int maxScore = 5;

    int gameMode;
    int rallyScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the ball
        Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);

        FindObjectOfType<AudioManager>().playAudio("GameTheme");

        gameMode = PlayerPrefs.GetInt("GameMode", 2);

        // Single Player Mode
        if(gameMode == 1)
        {
            rallyScore = 0;
            GameObject.FindGameObjectWithTag("PlayerBlue").GetComponent<PlayerMovementBotScript>().enabled = true;
            GameObject.FindGameObjectWithTag("PlayerBlue").GetComponent<PlayerMovementScript>().enabled = false;
            scoreText.text = "Score : " + rallyScore.ToString();
        }
        else if(gameMode == 2)
        {
            GameObject.FindGameObjectWithTag("PlayerBlue").GetComponent<PlayerMovementBotScript>().enabled = false;
            GameObject.FindGameObjectWithTag("PlayerBlue").GetComponent<PlayerMovementScript>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementPlayerScore(int player, int val)
    {
        if(player == 1)
        {
            playerRedScore += val;
        }
        else if (player == 2)
        {
            playerBlueScore += val;
        }

        scoreText.text = playerRedScore.ToString() + " : " + playerBlueScore.ToString();

        if(playerRedScore != maxScore && playerBlueScore != maxScore)
        {
            // Respawn Ball
            // playerRed.transform.position = new Vector3(playerRed.transform.position.x, 0, 0);
            // playerBlue.transform.position = new Vector3(playerBlue.transform.position.x, 0, 0);
            // Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);

            // Instantiate spawnTimer
            Instantiate(spawnCounterObject, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            gameOver();
        }
    }

    public void spawnBall()
    {
        playerRed.transform.position = new Vector3(playerRed.transform.position.x, 0, 0);
        playerBlue.transform.position = new Vector3(playerBlue.transform.position.x, 0, 0);
        Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void incrementRallyScore(int val)
    {
        rallyScore += val;
        scoreText.text = "Score : " + rallyScore.ToString();
    }

    public void gameOver()
    {
        if(gameMode == 1)
        {
            matchResultText.text = "Rally Score : " + rallyScore.ToString();
            gameOverPanel.SetActive(true);
            return;
        }

        if(playerRedScore == maxScore)
        {
            matchResultText.text = "Player Red Won the Game";
        }
        else if(playerBlueScore == maxScore)
        {
            matchResultText.text = "Player Blue Won the Game";
        }
        gameOverPanel.SetActive(true);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void endLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
