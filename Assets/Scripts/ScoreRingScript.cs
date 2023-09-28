using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRingScript : MonoBehaviour
{
    //the tag that must be on the other object of the trigger interaction
    //for points to be added.
    public string playerTag = "Player";

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

            //we destroy this object
            Destroy(this.gameObject);

        }

    }

}
