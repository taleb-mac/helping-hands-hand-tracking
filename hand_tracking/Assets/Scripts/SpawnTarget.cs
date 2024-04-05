using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnTarget : MonoBehaviour
{

    public GameObject target;
    public float[] rangeX;
    public float[] rangeY;
    public float[] choicesZ;
    public int[] distancesZ;
    public AudioClip[] distancesZAudio;
    int score = -1;
    public Text scoreText;
    public Text distanceText;
    public AudioSource audioSource;

    private void Start()
    {
        GetComponent<SpawnTarget>().Spawn();
    }

    public void Spawn()
    {
        int zAxis = Random.Range(0, choicesZ.Length);
        Vector3 pos = new Vector3(Random.Range(rangeX[0], rangeX[1]), Random.Range(rangeY[0], rangeY[1]), choicesZ[zAxis]);
        Instantiate(target, pos, Quaternion.identity);
        score++;
        scoreText.text = "Score: " + score;
        distanceText.text = "Distance: " + distancesZ[zAxis] + "cm";
        AudioClip clip = distancesZAudio[zAxis];
        audioSource.clip = clip;
        audioSource.PlayDelayed(0);
    }
}
