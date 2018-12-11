using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenChocolate : MonoBehaviour {

    // Define Variables
    public float Direction;
    public Rigidbody2D RB2D;
    public float angle = 0;

    // Use this for initialization
    void Start()
    {

        // Define Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();

        // Set the float "angle" to a random number between -1000 and 1000
        angle = Random.Range(-1000, 1000);

        // Using the angle float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.left * angle);

        // Set the float "Direction" to a random number between -150 and 150
        Direction = Random.Range(-150, 150);

        // Using the Direction float that has just been determined, add a force to the Rigidbody2D
        RB2D.AddForce(Vector2.up * Direction);

    }
    
}
