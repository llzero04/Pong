using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCounter : MonoBehaviour
{
    // public Text SpawnTimerText;

    float spawnTimer = 4f;
    // Text spawnTimerText = null;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Text[] texts = Text.FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if(text.name.Equals("SpawnTimerText"))
            {
                spawnTimerText = text;
            }
        }
        spawnTimer = 0f;
        */

        /*
        Text[] texts = GameObject.FindObjectsOfType<Text>();
        foreach (Text text in texts)
        {
            if(text.gameObject.tag.Equals("SpawnTimerText") == true)
            {
                spawnTimerText = text;
                break;
            }
        }

        spawnTimerText.enabled = true;
        */

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0f)
        {
            FindObjectOfType<GameManager>().spawnBall();
            Destroy(gameObject);
        }
        else
        {
            // int time = (int)spawnTimer;
            // spawnTimerText.text = time.ToString();
        }
    }
}
