using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBotScript : MonoBehaviour
{
    public Rigidbody2D playerRb;

    int moveDirection = 0;
    float playerSpeed = 400f;
    Vector2 velocityVector = Vector2.zero;

    float offset = 0f;
    float smoothSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 0;
        offset = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if(ball == null)
        {
            return;
        }
        Vector3 ballPosition = ball.transform.position;
        Vector3 currPos = gameObject.transform.position;
        if (ballPosition.y + offset <= 4.25f && ballPosition.y + offset >= -4.25f)
        {
            Vector3 finalPos = new Vector3(currPos.x, ballPosition.y + offset, currPos.z);
            // gameObject.transform.position = new Vector3(currPos.x, ballPosition.y + offset, 0);
            gameObject.transform.position = Vector3.Lerp(currPos, finalPos, smoothSpeed);
        }
        else
        {

        }
    }

    private void FixedUpdate()
    {
        /*
        if (moveDirection != 0)
        {
            movePlayer();
        }
        else if (moveDirection == 0)
        {
            ceaseMovementOfPlayer();
        }
        */
    }

    public void setOffset()
    {
        float high = 0.5f;
        float low = -0.5f;

        offset = Random.Range(low, high);
        smoothSpeed = Random.Range(0.25f, 0.75f);
    }

    private void movePlayer()
    {
        velocityVector.y = playerSpeed * Time.deltaTime * moveDirection;
        playerRb.velocity = velocityVector;
        moveDirection = 0;
    }

    private void ceaseMovementOfPlayer()
    {
        velocityVector.y = 0;
        playerRb.velocity = velocityVector;
    }
}
