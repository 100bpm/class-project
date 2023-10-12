using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    // the speed of the projectile
    public float speed;
    //how long will this projectile last before self-destruction
    public float lifetime;
    //count that keeps track of how long this projectile has been around for 
    private float lifetimeCounter = 0 ;


    // Update is called once per frame
    void Update()
    {
        //we use the function (to keep update clean)
        MoveProjectile();
        //deltatie is added to hte counter
        lifetimeCounter += Time.deltaTime;
        //if the counter has exceded the lifetime
        if (lifetimeCounter > lifetime) {

            //destory this
            Destroy(this.gameObject);
        }
        
    }


    void MoveProjectile()
    {   //we define a new position vector to easily modify its values 
        Vector3 newPos = transform.position;
        //We set new posiiton 
        newPos += transform.forward * speed * Time.deltaTime;

        //set the new posotion of the object
        transform.position = newPos;
    }
}
