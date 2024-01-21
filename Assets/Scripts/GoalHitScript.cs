using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHitScript : MonoBehaviour
{
    // 1 is a score for playerRed, 2 is a score for playerBlue
    public int playerGoalIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Ball") == true)
        {
            FindObjectOfType<AudioManager>().playAudio("GoalHit");
            if(playerGoalIndicator == 1) 
            {
                FindObjectOfType<GameManager>().incrementPlayerScore(playerGoalIndicator, 1);
            }
            else if(playerGoalIndicator == 2)
            {
                FindObjectOfType<GameManager>().incrementPlayerScore(playerGoalIndicator, 1);
            }
            Destroy(collision.gameObject);
        }
    }
}
