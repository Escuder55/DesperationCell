using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCheckThisPoint : MonoBehaviour
{
    public Transform enemy;
    public NavMeshAgent agent;
    public Animator enemyAnimator;
    public GameObject killCharacter;
    bool isWalking = false;

    private void Update()
    {
        if (isWalking)
        {
            if (Vector3.Distance(enemy.position, this.transform.position) <= 0.3f)
            {
                isWalking = false;
                enemyAnimator.SetBool("WalkingLoop", false);
                enemyAnimator.SetBool("IdleLoop", true);
            }
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            agent.SetDestination(this.transform.position);
            isWalking = true;
            Destroy(killCharacter);
            enemyAnimator.SetBool("WalkingLoop", true);
            enemyAnimator.SetBool("IdleLoop", false);
        }
    }


}
