using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBehaviour : MonoBehaviour {

    // Define Variables
    public bool mousedown = false;
    public Vector2 localScale;
    public Vector2 DuplicateVector;
    public GameObject DuplicateObject;
    public bool Frozen = false;
    public Rigidbody2D RB2D;
    public GameObject CandyHalf1;
    public GameObject CandyHalf2;
    public int ThisCandyScore;
    public GameManagerScript GameManagerScript_;
    public Sprite FrozenSprite;
    public SpriteRenderer SR;
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

        // Define the SpriteRenderer
        SR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the "swordno" integer to a random number between 1 and 3
        swordno = Random.Range(1 , 3);

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

        // If a bubblegum piece has been broken in the last 5 seconds
        if (GameManagerScript_.BubbleGumPopped == true)
        {
            // Make the piece larger
            transform.localScale = new Vector2(2, 2);
        }

        else if (GameManagerScript_.BubbleGumPopped == false)
        {
            // If a bubblegum hasn't been broken in the last 5 seconds, then restore the piece to it's original size
            transform.localScale = new Vector2(1, 1);

        }


        // If a Chocolate has been broken in the last 0.045 seconds
        if (GameManagerScript_.Duplicate == true)
        {
            // Create a duplicate of this game object using the DuplicateVector variable
            Instantiate(DuplicateObject, DuplicateVector, transform.rotation);
        }

        // If an IceCream has been broken in the last 0.1 seconds
        if (GameManagerScript_.Freeze == true)
        {
            // Set the frozen boolean to true
            Frozen = true;
        }

        // Check if the frozen boolean is true
        if (Frozen == true)
        {
            // Change the sprite to the frozen variation
            SR.sprite = FrozenSprite;

            // Destroy this game object's Rigidbody2D
            Destroy(RB2D);
        }

        // If a Lemon Drop has been broken in the last 5 seconds
        if (GameManagerScript_.LemonDrop == true)
        {
            // Make the piece smaller
            transform.localScale = new Vector2(0.5f, 0.5f);
        }

    }

    // What to do when the mouse is over the piece of candy
    void OnMouseOver()
    {
        // What to do if the mouse is over the piece of candy and the mouse button is down
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

           // Increase the score variable in the Game Manager by whatever this candy's score is
           GameManagerScript_.Score += ThisCandyScore;

           // Create the two halves of the broken candy using the DuplicateVector variable
           Instantiate(CandyHalf1, DuplicateVector, transform.rotation);
           Instantiate(CandyHalf2, DuplicateVector, transform.rotation);

           // Destroy this game object
           Destroy(this.gameObject);
        }

        else
        {
            // If mouse is not down, do nothing
            return;
        }
        
    }

    // What to do when this candy collides with another candy
    private void OnCollisionEnter2D(Collision2D iscandy)
    {
        // Check if the object that this candy collided with has a "Candy" tag
        if (iscandy.gameObject.tag=="Candy")
        {
            // If yes, then ignore collision
            Physics2D.IgnoreCollision(iscandy.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
