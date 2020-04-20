using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] NavMeshAgent agent;
    SelectObject activateObject;
    TextBehaviour mytext;
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
                Debug.Log(hit.point);
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
                        if (mytext != null)
                            mytext.DoSwitch();
                        activate = false;
                    }
                }
            }
        }
    }

    

    public void interactuableClicked(Transform interactuable, GameObject gobj)
    {
        activate = true;
        activateObject = gobj.GetComponent<SelectObject>();
        if (gobj.GetComponent<TextBehaviour>())
            mytext = gobj.GetComponent<TextBehaviour>();
        else
            mytext = null;
        agent.SetDestination(interactuable.position);
    }
}
