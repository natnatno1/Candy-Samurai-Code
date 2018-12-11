using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour {

    // Define Variable
    public bool BubbleGumPopped = false;
    public float BubbleGumTimer = 5;
    public bool Duplicate = false;
    public float DuplicateTimer = 0.045F;
    public bool Freeze = false;
    public float FreezeTimer = 0.1F;
    public bool LemonDrop = false;
    public float LemonDropTimer = 5;
    public int Score = 0;
    public int scene;
    public GameObject canvas;
    public int Strike = 3;
    public List<int> HighScore = new List<int>();
    public List<string> PlayerName = new List<string>();
    public int NewHighScore;
    public string NewPlayerName;
    public HighScores HighScoresScript;
    public int PlayerNameInt;
    public GameObject MenuMusic;
    public GameObject GameOverMusic;
    public bool isplayerinputactive = true;

    // Do as soon as this game object is awake
    public void Awake()
    {
        // Make sure that this game object is not destroyed when the next scene is loaded
        DontDestroyOnLoad(this);

        // Check if there are any more of this game object in the scene
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If yes, then destroy this game object
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        // Deactivate the canvas
        canvas.SetActive(false);

        // Set the Strike variable to 3
        Strike = 3;

        // Add default high scores to the "HighScore" list
        HighScore.Add(3000);
        HighScore.Add(2000);
        HighScore.Add(1000);
        HighScore.Add(500);
        HighScore.Add(250);

        // Add default player names to the "PlayerName" list
        PlayerName.Add("Natalie");
        PlayerName.Add("Matt");
        PlayerName.Add("Katie");
        PlayerName.Add("Max");
        PlayerName.Add("Jimi");

        // Add an extra player name list which will not be shown
        PlayerName.Add("");

    }
	
	// Update is called once per frame
	void Update () {
        
        // Set the "scene" variable to the same value as the active scene's number in the build index
        scene = SceneManager.GetActiveScene().buildIndex;
       
        // Check if the current scene is the Main Menu or the Tutorial screens
        if (scene == 0 || scene == 1 || scene == 2 || scene == 3)
        {
            // If yes, activate the Menu Music
            MenuMusic.SetActive(true);

            // Deactivate the Game Over Music
            GameOverMusic.SetActive(false);
        }

        // Check if the current scene is the Main Game screen
        else if (scene == 4)
        {
            // If yes, deactivate the Menu Music
            MenuMusic.SetActive(false);

            // Deactivate the Game Over Music
            GameOverMusic.SetActive(false);
        }

        // Check if the current scene is the Game Over screen or the High Score screen
        else if (scene == 5 || scene == 6)
        {
            // If yes, deactivate the Menu Music
            MenuMusic.SetActive(false);

            // Activate the Game Over Music
            GameOverMusic.SetActive(true);
        }

        // Check if the current scene is the Main Game screen
        if (scene == 4)
        {
            // If yes, then activate the canvas
            canvas.SetActive(true);
        }

        else
        {
            // If no, then deactivate the canvas
            canvas.SetActive(false);

            // Set strike to 3
            Strike = 3;

            // Set score to 0
            Score = 0;

        }

        // Check if the Strike variable is 0 or lower
        if (Strike <= 0)
        {
            // If yes, call HighScores fuction
            HighScores();

            // Load the Game Over screen
            SceneManager.LoadScene(sceneBuildIndex: 5);
        }

        // Check if the BubbleGumPopped boolean is true
        if (BubbleGumPopped == true)
        {
            // If yes, then decrease the BubbleGumTimer variable over time
            BubbleGumTimer -= Time.deltaTime;

            // Check if the BubbleGumTimer variable is 0 or less
            if (BubbleGumTimer <= 0)
            {
                // If yes, then set the BubbleGumPopped variable to false
                BubbleGumPopped = false;

                // Reset the BubbleGumTimer variable to 5
                BubbleGumTimer = 5;
            }
        }

        // Check if the Duplicate boolean is true
        if (Duplicate == true)
        {
            // If yes, then decrease the DuplicateTimer variable over time
            DuplicateTimer -= Time.deltaTime;

            // Check if the DuplicateTimer variable is 0 or less
            if (DuplicateTimer <= 0)
            {
                // Set the Duplicate boolean to false
                Duplicate = false;

                // Reset the DuplicateTimer variable to 0.045
                DuplicateTimer = 0.045F;
            }
        }

        // Check if the LemonDrop boolean is true
        if (LemonDrop == true)
        {
            // If yes, then decrease the LemonDropTimer variable over time
            LemonDropTimer -= Time.deltaTime;

            // Check if the LemonDropTimer variable is 0 or less
            if (LemonDropTimer <= 0)
            {
                // Set the LemonDrop boolean to false
                LemonDrop = false;

                // Reset the LemonDropTimervariable to 5
                LemonDropTimer = 5;
            }
        }

        // Check if the Freeze boolean is true
        if (Freeze == true)
        {
            // If yes, then decrease the FreezeTimer variable over time
            FreezeTimer -= Time.deltaTime;

            // Check if the FreezeTimer variable is 0 or less
            if (FreezeTimer <= 0)
            {
                // Set the Freeze boolean to false
                Freeze = false;

                // Reset the FreezeTimer to 0.1F
                FreezeTimer = 0.1F;
            }
        }

        // Check if the HighScore variable is more than or equal to the 4th value in the HighScore list
        if (Score >= HighScore[4])
        {
            // If yes, set the NewHighScore to the Score value
            NewHighScore = Score;
        }

    }


    // Controls the game's high scores
    public void HighScores()
    {
        // If the current score is higher than the 0 value in the HighScore list
        if (HighScore[0] <= Score)
        {
            // If yes, then set each entry of the HighScore list after the 0 entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];
            HighScore[2] = HighScore[1];
            HighScore[1] = HighScore[0];

            // Set the 0 entry of the HighScore list to the new score
            HighScore[0] = Score;

            // Set each entry of the PlayerName list after the 0 entry to the next one 
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];
            PlayerName[2] = PlayerName[1];
            PlayerName[1] = PlayerName[0];

            // Set the 0 entry of the PlayerName list to nothing
            PlayerName[0] = "";

            // Set the PlayerNameInt variable to 0
            PlayerNameInt = 0;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;
        }

        // If the current score is not equal or higher than the 0 value in the HighScore list, then check if the current scoreis equal or higher than the 1st entry in the HighScore list
        else if (HighScore[1] <= Score)
        {
            // If yes, then set each entry of the HighScore list after the 1st entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];
            HighScore[2] = HighScore[1];
            
            // Set the 1st entry of the HighScore list to the current score
            HighScore[1] = Score;

            // Seteach entry of the PlayerName list after the 1st entry to the next one 
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];
            PlayerName[2] = PlayerName[1];

            // Set the 1st entry of the PlayerName list to nothing
            PlayerName[1] = "";

            // Set the PlayerNameInt variable to 1
            PlayerNameInt = 1;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;
        }
        
        // If the current score is not equal or higher than the 1st value in the HighScore list, then check if the current score is equal or higher than the 2nd entry in the HighScore list
        else if (HighScore[2] <= Score)
        {
            // If yes, then set each entry of the HighScore list after the 2nd entry to the next one
            HighScore[4] = HighScore[3];
            HighScore[3] = HighScore[2];

            // Set the 2nd entry in the HighScore list to the current score
            HighScore[2] = Score;

            // Set each entry of the PlayerName list after the 2nd entry to the next one
            PlayerName[4] = PlayerName[3];
            PlayerName[3] = PlayerName[2];

            // Set the 2nd entry in the PlayerName list to nothing
            PlayerName[2] = "";
            
            // Set the PlayerNameInt variable to 2;
            PlayerNameInt = 2;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;
        }

        // If the current score is not equal or higher than the 2nd value in the HighScore list, then check if the current score is equal or higher than the 3rd entry in the HighScore list
        else if (HighScore[3] <= Score)
        {
            // If yes, then set each entry of the HighScore list after the 3rd entry to the next one
            HighScore[4] = HighScore[3];

            // Set the 3rd entry in the HighScore list to the current score
            HighScore[3] = Score;

            // Set each entry in the PlayerName list after the 3rd entry to the next one
            PlayerName[4] = PlayerName[3];

            // Set the 3rd entry in the PlayerName list to nothing
            PlayerName[3] = "";

            // Set the PlayerNameInt variable to 3
            PlayerNameInt = 3;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;

        }

        // If the current score is not equal or higher than the 3rd value in the HighScore list, then check if the current score is equal or higher than the 4th entry in the HighScore list
        else if (HighScore[4] <= Score)
        {
            // If yes, then set the 4th entry in the HighScore list to the current score
            HighScore[4] = Score;

            // Set the 4th entry in the PlayerName list to nothing
            PlayerName[4] = "";

            // Set the PlayerNameInt variable to 4
            PlayerNameInt = 4;

            // Set the isplayeractive boolean to true
            isplayerinputactive = true;
        }

        // If the current score is less than the last vakue in the HighScore list
        else if (HighScore[4] > Score)
        {
            // If there is no new high score, set the PlayerNameInt variabe to 5 (so that it is set, but won't be seen)
            PlayerNameInt = 5;

            // Set the isplayeractive boolean to false
            isplayerinputactive = false;
            
        }
        
    }
    

}
