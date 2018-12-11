using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    // Define Variables
    public GameManagerScript GameManagerScript_;
    public int score;
    public bool mousedown = false;

    // Use this for initialization
    void Start () {

        // Define the Game Manager script
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // Set the score variable to the Score variable in the Game Manager script
        score = GameManagerScript_.Score;
	}
	
	// Update is called once per frame
	void Update () {

        // Set the Score variable in the Game Manager to the score value in this script
        GameManagerScript_.Score = score;
    }

}
