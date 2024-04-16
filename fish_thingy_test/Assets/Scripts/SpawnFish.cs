using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnFish : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] fishyPrefabs;


    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float maxLifetime = 5f;

    Text scoreText;
    Text distanceText;
    int score;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        distanceText = GameObject.FindGameObjectWithTag("Distance").GetComponent<Text>();
        SpawnFishy();
    }


    public void SpawnFishy()
    {
 
        GameObject prefab = fishyPrefabs[Random.Range(0, fishyPrefabs.Length)];


        Vector3 position = new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
      

        GameObject fish = Instantiate(prefab, position, Quaternion.identity);
        Destroy(fish, maxLifetime);
        distanceText.text = "Distance: " + ((Mathf.Round(position.z) - 42) * 10) + "cm";



    }
    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }
}
