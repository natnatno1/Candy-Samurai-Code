using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    // Define Variables
    public Text ScoreBox;
    public GameManagerScript GameManagerScript_;
    public int Score;
    public Text StrikeBox;
    public int Strike;


	// Use this for initialization
	void Start () {

        // Define the ScoreBox
        ScoreBox = GameObject.Find("Score").GetComponent<Text>();

        // Define he StrikeBox
        StrikeBox = GameObject.Find("Strike").GetComponent<Text>();

        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {

        // Set Score variable to the score variable in the Game Manager script
        Score = GameManagerScript_.Score;

        // Display the Score variable in the ScoreBox
        ScoreBox.text = "" + Score;

        // Set Strike variable to the strike variable in the Game Manager script;
        Strike = GameManagerScript_.Strike;

        // Display the Strike variable in the StrikeBox
        StrikeBox.text = "" + Strike;

     

        

    }
}
