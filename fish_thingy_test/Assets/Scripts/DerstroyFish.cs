using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerstroyFish : MonoBehaviour
{

    public GameObject juice;
    SpawnFish spawn;

    private void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnFish>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            juice = Instantiate(juice, transform.position, Quaternion.identity);
            spawn.IncreaseScore(1);
            Destroy(juice, 2);
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        spawn.SpawnFishy();
    }
}
