using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_Animation : MonoBehaviour {

    // Define Variables
    private Vector2 mousePosition;
    public float moveSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        // Set the mousePosition vector to the value of the mouse position in the game
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        // Check if the mouse button is down
        if (Input.GetButtonDown("Fire1"))
        {
            // If yes, enable the trail renderer
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            // If no, then disable the trail renderer
            gameObject.GetComponent<TrailRenderer>().enabled = false;
        }

    }
}
