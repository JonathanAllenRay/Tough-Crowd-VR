using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowables : MonoBehaviour {

    // Make random objects spawn around the player 

    private int time_between_spawns;

    private int spawn_amount;

    public GameObject[] throwables; // add prefabs to spawn

    public GameObject[] spawnPoints; // place the spawn points (create a new empty game object

    public GameObject SpawnFX; // spawn particle effect 

    public float radius = 2;

    int randomInt;

    int randomIntTwo;

    //int randomNumPos;

    //int randomNumNeg;

    // int randomPos;

    Vector3 randomVec;

    //Vector3 randomVec2;

    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float stopSpawnTimeEvery; // stop spawning every ___ seconds 


    // Use this for initialization
    void Start () {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint"); // make sure spawn points are taged
	}
	
	// Update is called once per frame
	void Update () {

        InvokeRepeating("SpawnRandom", spawnTime, spawnDelay);

        InvokeRepeating("StopSpawn", spawnTime, stopSpawnTimeEvery);

        //SpawnRandom();

    }

    int GetRandom(int count) // helper function
    {
        return Random.Range(0, count); // get a random range from 
    }

    Vector3 GetRandomVector (Vector3 vec) // gets the random vector
    {
        return (Random.insideUnitSphere * radius) + vec;
    }

    /*
    Vector3 GetRandomPosition () // add this to the position of the spawners to improve randomness (so they don't stack up)
    {
        randomNumPos = Random.Range(0, 5);
        randomNumNeg = Random.Range(0, 3);
        randomPos = randomNumPos - randomNumNeg;

        return (new Vector3(randomPos, randomPos, randomPos));
    }
    */
    void SpawnRandom()
    {
        GameObject tempFX;

        randomInt = GetRandom(throwables.Length);
        randomIntTwo = GetRandom(spawnPoints.Length);
        randomVec = GetRandomVector(spawnPoints[randomIntTwo].transform.position);
        //randomVec2 = GetRandomPosition();
        Instantiate(throwables[randomInt], randomVec, spawnPoints[randomIntTwo].transform.rotation);

        tempFX = Instantiate(SpawnFX, randomVec, spawnPoints[randomIntTwo].transform.rotation);

        Destroy(tempFX, 1);

        if (stopSpawning)
        {
            CancelInvoke("SpawnRandom");
            // Do something
        }
    }

    void StopSpawn()
    {
        if (stopSpawning){
            stopSpawning = false;
        }
        else
        {
            stopSpawning = true;
        }
    }
}
