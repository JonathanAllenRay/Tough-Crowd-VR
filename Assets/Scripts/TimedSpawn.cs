using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject throwable; // place your designated object a spawn time
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
		
	}
	
	public void SpawnObject()
    {
        Instantiate(throwable, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
            // Do something
        }
    }
}
