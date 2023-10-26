using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //the maximum and minimum position of the ship in each axis
    public Vector2 movBoundMin;
    public Vector2 movBoundMax;

    //the speed of x and y 

    public float speed;

    [Header("animations")]
    //the animator that controls the ship animations
    public Animator animator;
    //the parameter that controls the animations in x
    public string xAnimParam;
    //the parameters that controls the animations in y
    public string yAnimParam;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {

        #region Example
        /* //Debug.Log("Tick");

                 Vector3 newPos = this.gameObject.transform.position;

                 newPos.z += speed * Time.deltaTime;
                 //same as saying newPos.z = newPOos.z +speed;

                 //This is the same as saying that
                 this.gameObject.transform.position = newPos;
                 //this.gameObject.transform.position.z =
                 //  this.gameObject.transform.position.z + speed;*/
        #endregion

        //We declare the variables keeping track of player input
        float xMov;
        float yMov;

        //We store the player input
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        //forward the value of xmov and ymov to the animator it will
        //know hwere to go from there.
        animator.SetFloat (xAnimParam, xMov);
        animator.SetFloat (yAnimParam, yMov);

        //We declare a variable with the motion the player is making
        //                           v horixontal direction
        //                                 v vertical direction
        //                                            v the speed of both directions
        //                                                    v deltaTime to remoe 
        Vector3 motion = new Vector3(xMov, yMov, 0) * speed * Time.deltaTime;

        //a temp variable to check for boundaries
        Vector3 finalPos = transform.position + motion;

        if (finalPos.x > movBoundMax.x)
            finalPos.x = movBoundMax.x;
        if (finalPos.x < movBoundMin.x)
            finalPos.x = movBoundMin.x;

        if (finalPos.y > movBoundMax.y)
            finalPos.y = movBoundMax.y;
        if (finalPos.y < movBoundMin.y)
            finalPos.y = movBoundMin.y;

        //we change position by adding the motion 
       // transform.position += motion; 

        transform.position = finalPos;
    }
}
