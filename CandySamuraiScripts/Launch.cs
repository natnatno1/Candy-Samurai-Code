using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    // Define Variables
    public float Direction;
    public Rigidbody2D RB2D;
    public float angle = 0;


    void Start() {

        // Define the Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();

        // Set the Direction variable to 700
        Direction = 700;

        // Set the angle variable to a random number between -1500 and 1500
        angle = Random.Range(-1500, 1500);

        // Using the Direction float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.up * Direction);

        // Using the angle float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.left * angle);


    }
    
}
