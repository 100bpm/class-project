using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRingScript : MonoBehaviour
{

    [Header("Collision Detection")]
    //the tag that must be on the other object of the trigger interaction
    //for points to be added.
    public string playerTag = "Player";


    [Header("Particle Effect")]
    //the prefab of the particle effect thats gonna play when this ring is scored
    public Transform ringExplosion;

    [Header("Faking Destruction")]
    //the mesh of the ring, so that we can hide it
    public GameObject ringMesh;
    //the collider of the ring, so we can disable it
    public Collider ringCollider;

    [Header("Sound")]
    //the audio source that will play the scoring sound
    public AudioSource ringSoundPlayer;
    //the sound that will be played when points are scored
    public AudioClip scoreSound;

    private void Start()
    {
        //we tell the audio source what clip it will play
        ringSoundPlayer.clip = scoreSound;
    }


    //This callback funciton will be called when a collider on the same object 
    //as this script enters a triger (or if tere is a trigger on this object colliding with an object) 
    private void OnTriggerEnter(Collider other)
    {
        //we display the name of the object we collided with 
        Debug.Log("Colided with object " + other.gameObject.name);


        //if the other objet has the scoring tag, this object is destroyed
        if (other.CompareTag(playerTag)) 
        {
            ScoreManager.Instance.AddScore(10);

            //spawn a ring explosion at the positon of this object, with its same rotation
            Instantiate(ringExplosion, 
                this.transform.position, 
                this.transform.rotation,
                this.transform);

            //we destroy this object
            //Destroy(this.gameObject);


            //instead of destroying this object, we're going to hide the ring
            //and the collider so the player thinks its destroyed
            ringMesh.SetActive(false);
            ringCollider.enabled = false;


            //Tell the player to play the sound assigned to its "clip" variable
            ringSoundPlayer.Play();


        }

    }

}
