using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //the key the player needs to press for shooting
    //public KeyCode shootKey;
    public string shootButton;

    //the projectile that we'll be shooting
    public Transform projectile; 
    //how many seconds pass between each shot
    public float fireRate;
    //an internal counter used to keep track of time passed between shots
    float fireCooldown = 0;
    // Update is called once per frame
    void Update()
    {
        //if the cooldown has reached the rate
        fireCooldown += Time.deltaTime;
        if (fireCooldown >= fireRate
            //if the game is not paused
            && PauseMenuScript.isPaused == false
            //&& !PauseMenuScript.isPaused
            //if the player is pressing the shoot button
            && Input.GetButtonDown(shootButton))
            //&& Input.GetButton(shootButton))
            //&& Input.GetButtonUp(shootButton))
        {
            //shoot
            Shoot();

            fireCooldown = 0;
        
        }

    }

    void Shoot()
    {
        //The projectile is spawned at the position of this transform
        //with default rotation
        //Instantiate(projectile, transform.position, Quaternion.identity);
        
        //with the muzzle's rotation
        Instantiate(projectile, transform.position, transform.rotation);
    


    }
}
