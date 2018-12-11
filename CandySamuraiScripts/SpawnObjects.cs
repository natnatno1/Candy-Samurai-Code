using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    // Define Variables
    public GameObject[] CandySpawns;
    public GameObject[] SpecialCandySpawns;
    public float SpawnTimer;
    public Vector2 StartVector;
    public int SpawnNumber;
    public float SpecialSpawnTimer;

	// Use this for initialization
	void Start () {

        // Set the StartVector
       StartVector = new Vector2(0, -6);

        // Set the SpawnTimer to 2
        SpawnTimer = 2;

        // Set the SpecialSpawnTimer to 7
        SpecialSpawnTimer = 7;

    }
	
	// Update is called once per frame
	void Update () {

        // Decrease the value of the SpawnTimer over time
        SpawnTimer -= Time.deltaTime;

        // Check if the SpawnTimer value is 0 or less
        if (SpawnTimer <= 0)
        {
            // If yes, then set the SpawnNumber variable to a random number between 0 and 3
            SpawnNumber = Random.Range(0, 3);

            // Loop for whatever the value of SpawnNumber is
            for (int x = 0; x <= SpawnNumber; x++)
                {
                // Create a random candy from the CandySpawns list at the StartVector
                  Instantiate(CandySpawns[Random.Range(0, 5)], StartVector, transform.rotation);

                // Reset the SpawnTimer to a random number between 2 and 4
                  SpawnTimer = Random.Range(2,4);
                }
        }

        // Decrease the value of the SpecialSpawnTimer over time
        SpecialSpawnTimer -= Time.deltaTime;

        // Check if the SpawnTimer is 0 or less
        if (SpecialSpawnTimer <= 0)
        {
            // If yes, then create a random special candy from the SpecialCandySpawns list at the StartVector
            Instantiate(SpecialCandySpawns[Random.Range(0, 7)], StartVector, transform.rotation);

            // Reset the SpecialSpawnTimer to a random number between 7 and 10
            SpecialSpawnTimer = Random.Range(7, 10);
            
        }

        

    }
}
