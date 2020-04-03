using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speedFollowing;
    [SerializeField] float maxDistance;
    float distance;

    private void Awake()
    {
        this.transform.position = target.position;    
    }

    void Update()
    {
        distance = Vector3.Distance(this.transform.position, target.position);

        if (distance >= maxDistance)
        {
            this.transform.DOMove(target.position, speedFollowing);
        }
    }

}
