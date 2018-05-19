using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour {

    public List<GameObject> crowd;

    private GameObject Scoreboard_Timer;
    // Use this for initialization
    void Start() {
        crowd = new List<GameObject>(GameObject.FindGameObjectsWithTag("Audience"));
        InvokeRepeating("activateAudience", 0.0f, Random.Range(3.0f, 5.0f));
        Scoreboard_Timer = GameObject.Find("ScoreBoard_Timer");
    }

    private void Update()
    {
        crowd = new List<GameObject>(GameObject.FindGameObjectsWithTag("Audience"));
    }

    void activateAudience()
    {
        crowd = new List<GameObject>(GameObject.FindGameObjectsWithTag("Audience"));
        if (crowd.Count > 0)
        {
            int index = Random.Range(0, crowd.Count - 1);
            GameObject temp = crowd[index];
            temp.GetComponent<ThrowPrefab>().activeAudience = true;
            crowd.Remove(temp);
        }
        else
        {
            endGame();
        }
    }

    void endGame()
    {
        // Do something later
        Scoreboard_Timer.GetComponent<Timer>().is_audience_there = false;
            
    }
}
