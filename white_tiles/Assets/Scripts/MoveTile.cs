using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveForward();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void MoveForward()
    {
        rb.velocity = new Vector3(0f, 0f, -speed*50);
    }

}
