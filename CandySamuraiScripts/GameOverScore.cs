using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

    // Define Variables
    public Text Score;
    public GameManagerScript GameManagerScript_;
	
	// Update is called once per frame
	void Update () {

        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // Set the text value in the Score Game object to the NewHighScore variable in the Game Manager script
        Score.text = "" + GameManagerScript_.NewHighScore;
		
	}
}
