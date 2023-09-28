using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingscript : MonoBehaviour
{
    //three game objects with the asteroids that we will be moving
    public Transform firstPiece;
    public Transform secondPiece;
    public Transform thirdPiece;
    //piece thats currently at the front 
    public Transform currentFrontPiece;
    
    //time btween each piece movement
    public float switchTime = 0;
    //a time to keep track of time bewteen switches
    private float timePassed = 0;
    //the resulting z-axis distance between a new front piece and the old front piece
    public float switchDistance = 0;

    // Update is called once per frame
    void Update()
    {



        /*the delta time is added to the timePassed variable to keep track of 
         time passed since a switch */
        timePassed += Time.deltaTime;
        //if amount of time required for a switch has passed
        if (timePassed > switchTime)
        {
            if (firstPiece.position.z < secondPiece.position.z)
            {
                if (firstPiece.position.z < thirdPiece.position.z)
                {
                    //the first peice is the one at the back
                    firstPiece.transform.position = 
                        currentFrontPiece.position + 
                        Vector3.forward * switchDistance;

                    currentFrontPiece = firstPiece;
                    //is the same as saying
                    /* firstPiece.transform.position =
                         currentFrontPiece.position + new Vector3(0,0,1) * switchDistance;*/
                }

                else
                {
                    //third piece is the one at the back 
                    thirdPiece.transform.position =
                       currentFrontPiece.position +
                       Vector3.forward * switchDistance;

                    currentFrontPiece = thirdPiece;
                }

            }
            else 
            {
                if (secondPiece.position.z < thirdPiece.position.z)
                {
                    //the second peice is the one at the back
                    secondPiece.transform.position =
                       currentFrontPiece.position +
                       Vector3.forward * switchDistance;

                    currentFrontPiece = secondPiece;
                }

                else
                {
                    //third piece is the one at the back 
                    thirdPiece.transform.position =
                       currentFrontPiece.position +
                       Vector3.forward * switchDistance;

                    currentFrontPiece = thirdPiece;
                }
            }

            timePassed = 0;
        }
    }
}
