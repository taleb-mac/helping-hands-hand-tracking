using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;



    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnTarget>().Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        PlaceLandmarks();
    }


    void PlaceLandmarks()
    {
        string data = udpReceive.data;

        if (data.Length > 5)
        {
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);
            string[] points = data.Split(',');


            for (int i = 0; i < 21; i++)
            {
                if (points.Length >= i * 3 + 2)
                { 
                    float x = 7 - float.Parse(points[i * 3]) / 100;
                    float y = float.Parse(points[i * 3 + 1]) / 100;
                    float z = float.Parse(points[i * 3 + 2]) / 100;

                    handPoints[i].transform.localPosition = new Vector3(x, y, z);
                }
            }
        }
    }

}
