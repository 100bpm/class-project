using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    //thename of te input button that will pause the game
    public string pauseInputName;
    //A static variable to keep track of whether the game is paused
    public static bool isPaused = false;
    //the object with the pause menu
    public GameObject pauseMenuObeject;

    // Start is called before the first frame update
    void Start()
    {
        unPause();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(pauseInputName)) 
        {
            if (!isPaused)
                Pause();

            else
                unPause();
        
        }
    }

    //the function that will pause the game
    public void Pause() 
    {
        //the pause menu is shown
        pauseMenuObeject.SetActive(true);
        //timescale is set to 0, freezing time
        Time.timeScale = 0f;
        //isPaused is set to true
        isPaused = true;
    }

    //the function that will unpause the game
    public void unPause() 
    {
        //the pause menu is hidden
        pauseMenuObeject.SetActive(false);
        //set time to normal
        Time.timeScale = 1f;
        //isPaused is set to false
        isPaused = false;
    }
}
