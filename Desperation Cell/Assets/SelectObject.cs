using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    public GameObject outliner;

    public void OnMouseOver()
    {
        Debug.Log("RATON ENCIMA");
        outliner.SetActive(true);
    }

    public void OnMouseExit()
    {
        Debug.Log("RATON SALE");
        outliner.SetActive(false);
    }
}
