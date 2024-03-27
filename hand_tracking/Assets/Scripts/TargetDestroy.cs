using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    SpawnTarget spawner;
    bool hit = false;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnTarget>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hit)
        {
            spawner.Spawn();
            hit = true;
            Destroy(this.gameObject);
        }
    }
}
