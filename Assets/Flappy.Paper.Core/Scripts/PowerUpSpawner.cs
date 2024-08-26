using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject Powerup_health;
    public int powerUpPoolSize = 1;                                  //How many columns to keep on standby.
    public float spawnRate = 30f;                                    //How quickly columns spawn.
    public float powerupPosYMin = -1f;                                   //Minimum y value of the column position.
    public float powerupPosYMax = 3.5f;                                  //Maximum y value of the column position.

    private GameObject[] powerups;                                   //Collection of pooled columns.
    private int currentpowerUp = 0;                                  //Index of the current column in the collection.

    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);       //A holding position for our unused columns offscreen.
    private float spawnXPosition = 16.5f;

    private float timeSinceLastSpawned;

    private bool isSpawned;

    void Start()
    {

        timeSinceLastSpawned = 0f;

        powerups = new GameObject[powerUpPoolSize];
        for (int i = 0; i < powerUpPoolSize; i++)
        {
            powerups[i] = (GameObject)Instantiate(Powerup_health, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {

        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(powerupPosYMin, powerupPosYMax);

            powerups[currentpowerUp].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentpowerUp++;

            if (currentpowerUp >= powerUpPoolSize)
            {
                currentpowerUp = 0;
            }
        }
    }
}
