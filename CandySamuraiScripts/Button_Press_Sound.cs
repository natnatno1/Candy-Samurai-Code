using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Press_Sound : MonoBehaviour {

    // Define Variables
    public float Destroyin;

    // Use this for initialization
    void Start()
    {
        // Make sure that this game object is not destroyed when the next scene is loaded
        DontDestroyOnLoad(this.gameObject);

        // Set the Destroyin variable to 3
        Destroyin = 3;

    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the Destroyin variable over time
        Destroyin -= Time.deltaTime;

        // Check if the Destroyin variable is 0 or less
        if (Destroyin <= 0)
        {
            // If yes, then destroy this game object
            Destroy(this.gameObject);
        }
        
    }

}
