using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLandmarks : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;

    private Vector3 direction;
    public Vector3 Direction => direction;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
        direction = new Vector3(destination.position.x - origin.position.x, destination.position.y - origin.position.y, 0);

    }
}
