using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectObject : MonoBehaviour
{
    public GameObject outliner;
    public Transform destinationPosition;

    public Transform target;
    public float speed;

    public void OnMouseOver()
    {
        
        outliner.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            MoveObject();
        }
    }

    public void OnMouseExit()
    {
        
        outliner.SetActive(false);
    }

    void MoveObject()
    {
        this.transform.DOMove(target.position, speed);
    }
}
