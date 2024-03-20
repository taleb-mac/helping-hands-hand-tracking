using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{

    public GameObject target;
    public float[] rangeX;
    public float[] rangeY;
    public float[] rangeZ;


    public void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(rangeX[0], rangeX[1]), Random.Range(rangeY[0], rangeY[1]), Random.Range(rangeZ[0], rangeZ[1]));
        Instantiate(target, pos, Quaternion.identity);
    }
}
