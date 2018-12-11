using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    // Define Variables
    public GameManagerScript GameManagerScript_;
    public int NewHighScore;
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;
    public Text Score5;
    public InputField InputPlayerName;
    public Text YourName;
    public string PlayerName;
    public int PlayerNameInt;

    // Use this for initialization
    void Start () {

        // Define the script for the Game Manager
        GameManagerScript_ = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // Set the NewHighScore variable to the Score variable in the Game Manager script
        NewHighScore = GameManagerScript_.Score;
       
	}
	
	// Update is called once per frame
	void Update () {

        // Set the PlayerNameInt variable to the PlayerNameInt variable from the Game Manager script
        PlayerNameInt = GameManagerScript_.PlayerNameInt;

        // Add the entries from the HighScore list in the Game Manager to their relevent text boxes
        Score1.text = "" + GameManagerScript_.PlayerName[0] + "- " + GameManagerScript_.HighScore[0];
        Score2.text = "" + GameManagerScript_.PlayerName[1] + "- " + GameManagerScript_.HighScore[1];
        Score3.text = "" + GameManagerScript_.PlayerName[2] + "- " + GameManagerScript_.HighScore[2];
        Score4.text = "" + GameManagerScript_.PlayerName[3] + "- " + GameManagerScript_.HighScore[3];
        Score5.text = "" + GameManagerScript_.PlayerName[4] + "- " + GameManagerScript_.HighScore[4];

        // Set the NewPlayerName variable in the Game Manager script to what the player inputs into the Input Field
        GameManagerScript_.NewPlayerName = InputPlayerName.text;

        // Add the new player name at the PlayerNameInt value entry in the PlayerName list to the NewPlayerName variable in the Game Manager Script
        GameManagerScript_.PlayerName[PlayerNameInt] = GameManagerScript_.NewPlayerName;

        // Check if the isplayerinputactive boolean in the Game Manager is true
        if (GameManagerScript_.isplayerinputactive == false)
        {
            // If no, deactivate the input field
            InputPlayerName.gameObject.SetActive(false);

            // Deactivate the "Your Name" textbox
            YourName.gameObject.SetActive(false);
        }

        else if (GameManagerScript_.isplayerinputactive == true)
        {
            // If yes, activate the input field
            InputPlayerName.gameObject.SetActive(true);

            // Avtivate the "Your Name" textbox
            YourName.gameObject.SetActive(true);
        }



    }
}
