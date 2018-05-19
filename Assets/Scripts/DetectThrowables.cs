using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectThrowables : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // turns everything you grab into a throwable to throw back at the audience
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Prop")
        {
            other.tag = "Throwable";
        }

        if (other.tag == "Start")
        {
            SceneManager.LoadScene("FinalStageScene");
        }
        if (other.tag == "Exit")
        {
            Application.Quit();
        }
    }
}
