using UnityEngine;
using System.Collections.Generic;


public class Blade : MonoBehaviour
{
    public float sliceForce = 5f;

    private Vector3 direction;
    public Vector3 Direction => direction;

    public int framesToRecord = 100;
    public int framesToJump;
    private List<Vector3> recordedPositions = new List<Vector3>();



    private void Update()
    {
        recordedPositions.Add(transform.position);
        if (recordedPositions.Count > framesToRecord)
        {
            recordedPositions.RemoveAt(0);
        }

        direction = transform.position - GetPositionXFramesAgo(framesToJump);
    }

    public Vector3 GetPositionXFramesAgo(int framesAgo)
    {
        int index = Mathf.Clamp(recordedPositions.Count - framesAgo, 0, recordedPositions.Count - 1);
        return recordedPositions[index];
    }

}
