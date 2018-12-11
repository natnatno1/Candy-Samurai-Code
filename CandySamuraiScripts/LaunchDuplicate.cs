using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDuplicate : MonoBehaviour {
    
    // Define Variables
    public float Direction;
    public Rigidbody2D RB2D;
    public float angle = 0;

    // Use this for initialization
    void Start () {

        // Define the Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();

        // Set the angle variable to a random number between -1500 anf 1500
        angle = Random.Range(-1500, 1500);

        // Using the angle float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.left * angle);

    }
}
