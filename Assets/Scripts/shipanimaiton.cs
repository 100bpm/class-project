using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipanimaiton : MonoBehaviour
{
    //the animator component that willl make the ship spin
    public Animator animator;
    //the name of the spin parameter to set the trigger
    public string spinParameterName;

    //when this function is called the ship spins
    public void Spin()
    {
        //set the spin trigger on 
        animator.SetTrigger(spinParameterName);
    
    
    }



}
