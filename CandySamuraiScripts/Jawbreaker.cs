using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jawbreaker : MonoBehaviour {

    // Define Variables
    public bool mousedown = false;
    public Vector2 DuplicateVector;
    public GameObject NextJawbreaker;
    public int ThisCandyScore;
    public GameManagerScript GameManagerScript_;
    public int swordno;
    public GameObject Sword0;
    public GameObject Sword1;

    // Use this for initialization
    void Start () {
        

        // Define the Game Manager Script
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {

        // Set the swordno variable to a random number between 1 and 3
        swordno = Random.Range(1, 3);

        // Set the DuplicateVector value to this game object's vector value
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

    // What to do if the mouse is over the Jawbreaker
    void OnMouseOver()
    {
        // If the mouse is over the Jawbreaker, check if the mouse button is down
        if (mousedown == true)
        {
            // Check if the swordno variable = 1
            if (swordno == 1)
            {
                // If yes, then play the first Sword sound effect
                Instantiate(Sword0);
            }

            else if (swordno == 2)
            {
                // If no, then play the second Sword sound effect
                Instantiate(Sword1);
            }

            // Increase the score in the Game Manager by the value of the score by the Jawbreaker's score value
            GameManagerScript_.Score += ThisCandyScore;

            // Create the next size Jawbreaker using the DuplicateVector variable
            Instantiate(NextJawbreaker, DuplicateVector, transform.rotation); 

            // Destroy this game object
            Destroy(this.gameObject);
        }

        else
        {
            // If the mouse is not down, do nothing
            return;
        }
    }
}
