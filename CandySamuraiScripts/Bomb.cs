using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour {

    // Define Variables
    public bool mousedown = false;
    public GameManagerScript GameManagerScript_;
    public GameObject ExplosionAudio;

    // Use this for initialization
    void Start () {

        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {

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

    // What to do when the mouse is over the bomb
    void OnMouseOver()
    {
        //Check if the mouse button is down
        if (mousedown == true)
        {
            //Create explosion sound effect
            Instantiate(ExplosionAudio);

            //Load the "Game Over" screen
            SceneManager.LoadScene(sceneBuildIndex: 5);

            //Destroy the bomb
            Destroy(this.gameObject);
        }

        else
        {
            //If the mouse is over the bomb, but the mouse button is not down
            return;
        }

    }



}
