using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonDrop : MonoBehaviour {

    // Define Variables
    public bool mousedown = false;
    public Vector2 DuplicateVector;
    public GameObject lemondrophalf1;
    public GameObject lemondrophalf2;
    public int ThisCandyScore;
    public GameManagerScript GameManagerScript_;
    public int swordno;
    public GameObject Sword0;
    public GameObject Sword1;

    // Use this for initialization
    void Start () {

        // Define the Game Manager script
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }
	
	// Update is called once per frame
	void Update () {

        // Set the swordno variable to a random number between 1 and 3
        swordno = Random.Range(1, 3);

        // Set the DuplicateVector vector to the value of this game object's vector
        DuplicateVector = new Vector2(this.transform.position.x, this.transform.position.y);

        // Check if the mouse button is down
        if (Input.GetButtonDown("Fire1"))
        {
            // If yes, then set the mousebutton boolean to true
            mousedown = true;
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            // If no, then keep the mousebutton boolean to false
            mousedown = false;
        }

    }

    // What to do if the mouse is over the Lemon Drop
    void OnMouseOver()
    {
        // If the mouse is over the Lemon Drop, check if the mouse button is down
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

            // Increase the Score variable in the Game Manager script by the value of the Lemon Drop's score
            GameManagerScript_.Score += ThisCandyScore;
            
            // Set the LemonDrop boolean in the Game Manager script to true
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().LemonDrop = true;

            // Create the two halves for the Lemon Drop using the DuplicateVector variable
            Instantiate(lemondrophalf1, DuplicateVector, transform.rotation);
            Instantiate(lemondrophalf2, DuplicateVector, transform.rotation);

            // Destroy this game object
            Destroy(this.gameObject);
        }

        else
        {
            // If the mouse button is not down, do nothing
            return;
        }
    }
}
