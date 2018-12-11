using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    // Define Variables
    public int NextScene;
    public bool mousedown = false;
    public GameObject ButtonPressAudio;


    // Update is called once per frame
    void Update()
    {

        // Check if the mouse button is down
        if (Input.GetButtonDown("Fire1"))
        {
            // If yes, then set the mousedown boolean to true
            mousedown = true;
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            // If no, then keep the mousedown boolean to false
            mousedown = false;
        }

    }

    // What to do when the mouse is over the button
    void OnMouseOver()
    {
        // Check if the mouse button is down
        if (mousedown == true)
        {
            // If yes, then create button sound effect
            Instantiate(ButtonPressAudio);

            // Load the next scene as determined by the NextScene variable
            SceneManager.LoadScene(sceneBuildIndex: NextScene);
        }

        else
        {
            // If no, then do nothing
            return;
        }
    }
}

