using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    // Define Variables
    public GameManagerScript GameManagerScript_;

    // Use this for initialization
    void Start()
    {

        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }

    // What to do when this game object collides with another candy
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object that this game object collided with has a "Candy" tag
        if (other.gameObject.tag == "Candy")
        {
            // Decrease the Strike variable in the Game Manager by 1
            GameManagerScript_.Strike--;
        }

        // Destroy the candy that has collided with this game object
        Destroy(other.gameObject);
    }





}
