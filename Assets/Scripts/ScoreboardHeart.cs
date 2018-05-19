using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreboardHeart : MonoBehaviour {

    public TextMesh heartText;
    private bool over;

    // Use this for initialization
    void Start () {
        heartText.text = "Heart: 100%";
        over = false;
    }

    public void UpdateHealth(int healthLeft)
    {
        Debug.Log("In SCOREBOARDHEARTTTT");
        if (healthLeft > 0)
        {
            heartText.text = "Heart: " + healthLeft + "%";
        }
        else if (healthLeft <= 0 && !over)
        {
            GetComponent<AudioSource>().Play();
            over = true;
            loseGameAndReset();
        }
    }

    void loseGameAndReset()
    {
        heartText.text = "You're a loser!";
        Invoke("endGame", 5);
    }

    void endGame()
    {
        SceneManager.LoadScene("Menu");
    }
}

