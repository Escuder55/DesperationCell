using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWalls : MonoBehaviour
{
    [SerializeField] GameObject walls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            walls.SetActive(false);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            walls.SetActive(true);
        }
    }
}
