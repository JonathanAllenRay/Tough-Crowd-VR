using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAllText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("cleanupText", 20);
    }

    // Update is called once per frame
    void cleanupText () {
        List<GameObject> temp = new List<GameObject>(GameObject.FindGameObjectsWithTag("DeleteText"));
        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i]);
        }
    }
}
