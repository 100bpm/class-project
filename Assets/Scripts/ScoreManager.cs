using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    //the current score
    public int score = 0;
    //the text that will display the value of the score
    public TextMeshProUGUI scoreDisplay;

    public static ScoreManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        //we reset the score display to show the default value of the score
        scoreDisplay.text = score.ToString();
        //We set the instance to this script so it can be references from anywhere
        //in the game withouth having to look for it.
        Instance = this;
    }


    //the function that tells this script when to increase the score
    public void AddScore(int value) 
    {
        //add the value to the score
        score += value;
        //change the score
        scoreDisplay.text = score.ToString();
    }
}
