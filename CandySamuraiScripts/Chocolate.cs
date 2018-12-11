using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : MonoBehaviour {

    //Define Variables
    public bool mousedown = false;
    public Vector2 localScale;
    public Vector2 DuplicateVector;
    public GameObject Chocolatepiece;
    public int ThisCandyScore;
    public GameManagerScript GameManagerScript_;
    public int swordno;
    public GameObject Sword0;
    public GameObject Sword1;

    // Use this for initialization
    void Start()
    {
        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        // Set the "swordno" integer to a random number between 1 and 3
        swordno = Random.Range(1, 3);

        // Set the "DuplicateVector" vector to the same value as this object's vector
        DuplicateVector = new Vector2(this.transform.position.x, this.transform.position.y);

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

    // What to do when the mouse is over the chocolate
    void OnMouseOver()
    {
        // What to do if the mouse is over the chocolate and the mouse button is down 
        if (mousedown == true)
        {
            // Check if the swordno variable = 1
            if (swordno == 1)
            {
                // Play the first Sword sound effect
                Instantiate(Sword0);
            }

            else if (swordno == 2)
            {
                // Play the second Sword sound effect
                Instantiate(Sword1);
            }

            // Set the Duplicate variable in the Game Manager to true
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().Duplicate = true;

            // Increase the score variable in the Game Manager by whatever this candy's score is
            GameManagerScript_.Score += ThisCandyScore;

            // Loop 4 times
            for (int i = 0; i < 4; i++)
            {
                // Create a broken piece of chocolate using the DuplicateVector variable
                Instantiate(Chocolatepiece, DuplicateVector, transform.rotation);
            }

            // Destroy this game object
            Destroy(this.gameObject);
        }

        else
        {
            // If mouse button is not down, do nothing
            return;
        }
    }
}
