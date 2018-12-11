using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cake : MonoBehaviour {

    // Define Variables
    public bool mousedown = false;
    public GameManagerScript GameManagerScript_;
    public float Direction;
    public Rigidbody2D RB2D;
    public float angle = 0;
    public GameObject CandyHalf1;
    public GameObject CandyHalf2;
    public Vector2 DuplicateVector;
    public int swordno;
    public GameObject Sword0;
    public GameObject Sword1;

    // Use this for initialization
    void Start()
    {
        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // Define the Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();

        // Set the float "Direction" to 1000
        Direction = 1000;

        // Set the float "angle" to a random number between -1500 and 1500
        angle = Random.Range(-1500, 1500);

        // Using the Direction float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.up * Direction);

        // Using the angle float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.left * angle);

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

    // What to do when the mouse is over the cake
    void OnMouseOver()
    {
        // What to do when the mouse is over the cake and the mouse button is down
        if (mousedown == true)
        {
            // Check if the swordno variable = 1
            if (swordno == 1)
            {
                // Play the first Sword sound effect
                Instantiate(Sword0);
            }

            // Check if the swordno variable = 2
            else if (swordno == 2)
            {
                // Play the second Sword sound effect
                Instantiate(Sword1);
            }

            // Create the two halves of the broken candy using the DuplicateVector variable
            Instantiate(CandyHalf1, DuplicateVector, transform.rotation);
            Instantiate(CandyHalf2, DuplicateVector, transform.rotation);

            // Add 1 to the strike variable in the Game Manager
            GameManagerScript_.Strike++;

            // Destroy this game object
            Destroy(this.gameObject);
        }

        else
        {
            // If mouse is not down, do nothing
            return;
        }

    }
}
