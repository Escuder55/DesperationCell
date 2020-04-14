using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolCheckThisPoint : MonoBehaviour
{
    
    public NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            Debug.Log("Is Rcok Inside");
            agent.SetDestination(this.transform.position);
        }
    }


}
