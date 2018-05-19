using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObject : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("CleanObject", 7);
    }

    void CleanObject()
    {
        Destroy(gameObject);
    }
}

