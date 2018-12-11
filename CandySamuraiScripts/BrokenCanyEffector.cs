using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCanyEffector : MonoBehaviour {

    //Define Variables
    public bool mousedown = false;
    public GameManagerScript GameManager_;
    public Vector2 localScale;
    public Vector2 DuplicateVector;
    public GameObject DuplicateObject;
    public bool Frozen = false;
    public Rigidbody2D RB2D;
    public GameObject CandyHalf1;
    public GameObject CandyHalf2;

    // Use this for initialization
    void Start()
    {
        // Define the script for the Game Manager
        GameManager_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // Define Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // If a bubblegum piece has been broken in the last 5 seconds
        if (GameManager_.BubbleGumPopped == true)
        {
            // Make the broken piece larger
            transform.localScale = new Vector2(2, 2);
        }

        else if (GameManager_.BubbleGumPopped == false)
        {
            // if the bubblegum piece hasn't been broken in the last 5 seconds, then restore pieces to their original size
            transform.localScale = new Vector2(1, 1);

        }
        
        // If a lemon drop piece has been broken in the last 5 seconds
        if (GameManager_.LemonDrop == true)
        {
            // Make the broken pieces smaller
            transform.localScale = new Vector2(0.5f, 0.5f);
        }

    }
}
