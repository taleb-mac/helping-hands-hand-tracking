using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public AllowHit[] clickableAreas;
    int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RegisterHits();
    }

    void RegisterHits()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && clickableAreas[0].canHit)
        {
            Destroy(clickableAreas[0].tileHit);
            clickableAreas[0].flash();
            clickableAreas[0].canHit = false;
            score++;
            scoreText.text = "" + score;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && clickableAreas[1].canHit)
        {
            Destroy(clickableAreas[1].tileHit);
            clickableAreas[1].flash();
            clickableAreas[1].canHit = false;
            score++;
            scoreText.text = "" + score;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && clickableAreas[2].canHit)
        {
            Destroy(clickableAreas[2].tileHit);
            clickableAreas[2].flash();
            clickableAreas[2].canHit = false;
            score++;
            scoreText.text = "" + score;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && clickableAreas[3].canHit)
        {
            Destroy(clickableAreas[3].tileHit);
            clickableAreas[3].flash();
            clickableAreas[3].canHit = false;
            score++;
            scoreText.text = "" + score;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && clickableAreas[4].canHit)
        {
            Destroy(clickableAreas[4].tileHit);
            clickableAreas[4].flash();
            clickableAreas[4].canHit = false;
            score++;
            scoreText.text = "" + score;
        }
    }
}
