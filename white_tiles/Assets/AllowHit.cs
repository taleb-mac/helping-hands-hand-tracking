using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowHit : MonoBehaviour
{
    public int index;
    public bool canHit = false;

    public Material color;
    public Material white;
    public GameObject tileHit { get; private set; } = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tile")
        {
            canHit = true;
            tileHit = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            canHit = false;
            tileHit = null;
        }
    }

    public IEnumerator changeColor()
    {
        GetComponent<Renderer>().material = color;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material = white;
    }
    
    public void flash()
    {
        IEnumerator colorChange = changeColor();
        StopCoroutine(colorChange);
        StartCoroutine(colorChange);
    }





}
