using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automovement : MonoBehaviour
{
    //the speed of this object
    public float speed;

    // Update is called once per frame
    void Update()
    {   //make a new temporary vector
        Vector3 newPos = transform.position;

        //thenew position is = to 
        //(original position) + (direction * speed * deltatime (to avoid frame dependency))
        newPos += transform.forward * speed * Time.deltaTime;

        transform.position = newPos;
        
    }
}
