using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public TextMesh timerText;

    // end particle effects
    private GameObject[] EndParticles;

    // for the curtains
    private GameObject LeftCurtain;
    private GameObject RightCurtain;
    Animator leftC_animator;
    Animator rightC_animator;

    // timer
    public float GameLenght_min;
    private float startTime;
    private float currentTime;
    private float endTime;
    private bool done;

    public bool is_audience_there; // used for when there is no more audience

	// Use this for initialization
	void Start () {
        is_audience_there = true;
        startTime = Time.time;
        endTime = GameLenght_min * 60;
        done = false;
        GetCurtains(); // get the animators for the curtains
        EndParticles = GameObject.FindGameObjectsWithTag("EndParticles");

        for (int i = 0; i < EndParticles.Length; i++)
        {
            EndParticles[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        float t = Time.time - startTime;

        float remaining_t = endTime - t;

        if(is_audience_there == false)
        {
            GetComponent<AudioSource>().Play();
            winGameAndReset();
        }

        if (remaining_t <= 0) { 
            timerText.text = "You win!";
            if (!done)
            {
                done = true;
                GetComponent<AudioSource>().Play();
                winGameAndReset();
            }
            return;
        }

        string minutes = ((int)remaining_t / 60).ToString();
        string seconds = (remaining_t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds;
	}

    void winGameAndReset()
    {
        Destroy(GameObject.Find("Crowd"));

        for (int i = 0; i < EndParticles.Length; i++)
        {
            EndParticles[i].SetActive(true);
        }

        CloseCurtains();
        Invoke("endGame", 5);
    }

    void GetCurtains()
    {
        // sets up the curatain controllers
        LeftCurtain = GameObject.Find("ContainerLeftCurtain");
        RightCurtain = GameObject.Find("ContainerRightCurtain");
        leftC_animator = LeftCurtain.GetComponent<Animator>();
        rightC_animator = RightCurtain.GetComponent<Animator>();
    }

    void CloseCurtains()
    {
        // play the curtain animation
        bool GameTime0 = true;
        leftC_animator.SetBool("GameTime0", GameTime0);
        rightC_animator.SetBool("GameTime0", GameTime0);
    }

    void endGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
