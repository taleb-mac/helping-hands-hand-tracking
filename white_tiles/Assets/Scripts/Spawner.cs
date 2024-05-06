using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Material[] colors;
    public GameObject tiles;


    public int minWaitTime;
    public int maxWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnTiles");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTiles()
    {
        while (true)
        {

            Spawn();
            int randomWaitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
    
    void Spawn()
    {
        // Choose a random spawn position from the array
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn the object at the chosen position
        GameObject tile = Instantiate(tiles, spawnPoint.position, Quaternion.identity);

        tile.GetComponent<Renderer>().material = colors[randomIndex];
        tile.transform.GetChild(0).GetComponent<Renderer>().material = colors[randomIndex];
        tile.transform.localPosition += new Vector3(0f, 9f, 0f);

    }

}

