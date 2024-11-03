using UnityEngine;
using System.Collections;

public class ObjPool : MonoBehaviour
{
    public GameObject obstaclePrefab; //The obstacle game object.
    public int objPoolSize = 5; //How many obstacles to keep on standby.
    public float spawnRate = 4f; //How quickly obstacles spawn.
    public float columnMin = -1f; //Minimum y value of the obstacle position.
    public float columnMax = 3.5f; //Maximum y value of the obstacle position.

    private GameObject[] obstacles; //Collection of pooled obstacles.
    private int currentObstacle = 0; //Index of the current obstacle in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15, -25); //A holding position for our unused obstacles offscreen.
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        //Initialize thecollection.
        obstacles = new GameObject[objPoolSize];
        //Loop through the collection... 
        for (int i = 0; i < objPoolSize; i++)
        {
            //...and create the individual obstacles.
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }
    }


    //This spawns obstacles as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the obstacle
            float spawnYPosition = Random.Range(columnMin, columnMax);

            //...then set the current obstacle to that position.
            obstacles[currentObstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentObstacle. If the new size is too big, set it back to zero
            currentObstacle++;

            if (currentObstacle >= objPoolSize)
            {
                currentObstacle = 0;
            }
        }
    }
}