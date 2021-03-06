﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCandies2 : MonoBehaviour {

    // Define Variables
    public Rigidbody2D RB2D;

    // Use this for initialization
    void Start()
    {
        // Define Rigidbody2D
        RB2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Push the broken pieces to the top left
        transform.Rotate(Vector3.forward * -2);
        RB2D.AddForce(Vector2.left * 5);

    }
}
