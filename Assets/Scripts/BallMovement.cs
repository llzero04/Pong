using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ballRb;

    float ballSpeedInit = 5f;
    float ballSpeedMax = 20f;
    float ballSpeedIncrement = 1f;
    float currentBallSpeed = 0f;

    float yDiff = 0f;
    int xDirection = 0;
    float xMultiplier = 30f;
    float yMultiplier = 200f;

    Vector2 ballVelocityVector = Vector2.zero;

    int gameMode = 2;

    // Start is called before the first frame update
    void Start()
    {
        // Apply Initial velocity to ball
        xDirection = -1;
        currentBallSpeed = ballSpeedInit;
        // yDirection = 0;

        gameMode = PlayerPrefs.GetInt("GameMode", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        applyVelocityToBall();
    }

    private void applyVelocityToBall()
    {
        if(currentBallSpeed > ballSpeedMax)
        {
            currentBallSpeed = ballSpeedMax;
            yMultiplier += (1 * ballSpeedMax);
        }
        ballVelocityVector.x = currentBallSpeed * Time.deltaTime * xDirection * xMultiplier;
        ballVelocityVector.y = yDiff * Time.deltaTime * yMultiplier;
        ballRb.velocity = ballVelocityVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("PlayerRed") == true || collision.gameObject.tag.Equals("PlayerBlue") == true)
        {
            if(collision.gameObject.tag.Equals("PlayerRed") == true && gameMode == 1)
            {
                FindAnyObjectByType<PlayerMovementBotScript>().setOffset();
                FindAnyObjectByType<GameManager>().incrementRallyScore(1);
            }
            FindObjectOfType<AudioManager>().playAudio("BarHit");
            float playerY = collision.gameObject.transform.position.y;
            float ballY = transform.position.y;
            yDiff = ballY - playerY;
            xDirection = xDirection * -1;
            currentBallSpeed += ballSpeedIncrement;
            yMultiplier += 1;
        }
        else if(collision.gameObject.tag.Equals("BoundaryWall") == true)
        {
            yDiff = -1f * yDiff;
        }
    }
}
