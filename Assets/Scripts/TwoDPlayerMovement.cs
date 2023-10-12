using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerMovement : MonoBehaviour
{
    //the rigidbody that controls the physicics of this object
    public Rigidbody2D reggiebody;
    //the force of the jump
    public float jumpforce;
    //the movement speed of this character
    public float speed;

    //how far the player must be from the floor to jump
    public float minFloorDistance;
    //
    public Vector3 raycastOriginalOffset;
    //
    public float distanceBetweenRays;


    [SerializeField]
    bool raw;
    [SerializeField]
    private bool physicsmovement = true;

    // Start is called before the first frame update
    void Start()
    {
        reggiebody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (physicsmovement)
        {
            PhysicsMovement();
        }
       // else
        //{
         //   KinematicMovment();
     //}
    }
    // Update is called once per frame
    void PhysicsMovement()
    {
        //Ray2D floordetection = new Ray2D(this.transform.position, -Vector2.up);
        Debug.DrawRay(this.transform.position + raycastOriginalOffset,
           -Vector2.up * minFloorDistance, Color.red);

        bool middleRay = Physics2D.Raycast(this.transform.position + raycastOriginalOffset,
            -Vector2.up, minFloorDistance);
        bool leftRay = Physics2D.Raycast(this.transform.position + raycastOriginalOffset - Vector3.right * distanceBetweenRays,
            -Vector2.up, minFloorDistance);
        bool rightRay = Physics2D.Raycast(this.transform.position + raycastOriginalOffset + Vector3.right * distanceBetweenRays,
            -Vector2.up, minFloorDistance);


        //if the player presses the jump button
        if (Input.GetButtonDown("Jump")
            //we can cast the position to a vector2 for this operation, since the function 
            //takes in a vector 2 and our libraries already know how to convert vector 3 to vector 2
            //&&Physics2D.Raycast((Vector2)this.transform.position + raycastOriginalOffset,
            //&& Physics2D.Raycast(this.transform.position + raycastOriginalOffset,
            //-Vector2.up, minFloorDistance))
            //in this case we simply changed the type of raycastingOriginOffset to match
            && (leftRay || middleRay || rightRay))
        {
            //add force to the reggiebody upwards
            reggiebody.AddForce(Vector2.up * jumpforce);
        
        }
       
        float xMov;
        //get input of the player (represetned as (-1,1))
        if (raw) {
            xMov = Input.GetAxisRaw("Horizontal");
        }
        else
            xMov = Input.GetAxis("Horizontal");


        //we can add force to the right based on that, if we want an Icey movement
        //reggiebody.AddForce(Vector2.right * xMov * speed * Time.deltaTime);


        //or we can change the velocity directly. notice we're not changing the velcoity in y
        reggiebody.velocity = new Vector2(xMov * speed, reggiebody.velocity.y);
    }
}
