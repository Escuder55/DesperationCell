using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] NavMeshAgent agent;
    SelectObject activateObject;
    bool activate = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //MOVE AGENT
                agent.SetDestination(hit.point);
            }
            activate = false;
        }

        if (activate)
        {
            if (!agent.pathPending)
            {           
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        activateObject.DoAction();
                        activate = false;
                    }
                }
            }
        }
    }

    

    public void interactuableClicked(Transform interactuable, SelectObject gobj)
    {
        activate = true;
        activateObject = gobj;
        agent.SetDestination(interactuable.position);
    }
}
