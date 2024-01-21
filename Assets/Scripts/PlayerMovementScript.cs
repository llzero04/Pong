using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // 1 is red, 2 is blue
    public int player;
    public Rigidbody2D playerRb;

    // 1 is for +ve over y axis, -1 is -ve over y axis
    int moveDirection = 0;
    float playerSpeed = 400f;
    Vector2 velocityVector = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input for Red Player
        if(player == 1)
        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDirection = 1;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                moveDirection = -1;
            }
        }

        // Get Input for Blue Player
        if(player == 2)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                moveDirection = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDirection= -1;
            }
        }
    }

    private void FixedUpdate()
    {
        if(moveDirection != 0)
        {
            movePlayer();
        }
        else if(moveDirection == 0)
        {
            ceaseMovementOfPlayer();
        }
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
