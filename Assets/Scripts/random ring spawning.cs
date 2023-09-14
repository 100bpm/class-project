using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomringspawning : MonoBehaviour
{

    //defining n array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[6];
    //the seconds between the instantiation of each ring
    public float spawnRate = 1.0f;
    //acounter is used to kepe track of the time between ring instantiations
    private float spawnCounter = 0.0f;


    // Update is called once per frame
    void Update()
    {
        //the deltatime is added to the counter to keep track of time
        spawnCounter += Time.deltaTime;

        //if the counter has surpassed the rate, we're raedy to spawn something
        if (spawnCounter > spawnRate) 
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            //Spawn something
            Debug.Log("spawning ring at " + spawnPoints[randomIndex].name);

            //the conuter is reset
            spawnCounter = 0.0f;
        }
    }
}
