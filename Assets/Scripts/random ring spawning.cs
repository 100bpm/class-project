using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomringspawning : MonoBehaviour
{

    //the prefab with the ring that will be instantiated
    public Transform ringPrefab;

    //defining n array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[6];
    //the seconds between the instantiation of each ring
    public float spawnRate = 1.0f;
    //acounter is used to kepe track of the time between ring instantiations
    private float spawnCounter = 0.0f;

    private void Start()
    {
        //we start with the counter equal to the rate so rings start spawning right away 
        spawnCounter = spawnRate;
    }
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

            Debug.Log(spawnPoints[randomIndex].transform.position.ToString());

            //spawn the ring prefab at the position of the randomly selected
            //spawn point, with the rotation of said spawn point
            Instantiate(ringPrefab, spawnPoints[randomIndex].transform.position,
                spawnPoints[randomIndex].transform.rotation);

            //the conuter is reset
            spawnCounter = 0.0f;
        }
    }
}
