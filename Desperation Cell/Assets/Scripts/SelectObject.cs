using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.AI;

public class SelectObject : MonoBehaviour
{
    public GameObject outliner;
    public Transform target;
    public float speed;
    public bool movable = false;
    private bool Taken = false;
    private bool Falled = false;
    private bool Fired = false;

    //ENUMS
    public enum TypeInterectuable {OBJECTS, MOVABLE, INTERACTUABLE };
    public enum TypeObject {NONE, ROCK, BONE, STICK, HAMMER};
    public enum Uso {NONE, DOOR, TRAMPILLAIZQUIERDA, TRAMPILLADERECHA, WALL, CALDERO, DESK};
    [SerializeField] TypeObject type;
    [SerializeField] TypeInterectuable objects;
    [SerializeField] Uso use;

    //OBJETO A ESCONDER
    [SerializeField] GameObject Hide;

    //HUD VISUALIZAR
    [SerializeField] GameObject imageRock;
    [SerializeField] GameObject imageBone;
    [SerializeField] GameObject imageHammer;
    [SerializeField] GameObject imageStick;
    [SerializeField] GameObject imageTorch;

    //REFERENCIA SCRIPT INVENTARIO
    [SerializeField] GameObject refScript;
    [SerializeField] GameObject Player;

    //TELEPORT
    [SerializeField] Transform toRight;
    [SerializeField] Transform toLeft;

    //POINT FOR CHARACTER
    [SerializeField] Transform pointForPlayer;

    public void OnMouseOver()
    {
        outliner.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {            
            Player.GetComponent<PlayerController>().interactuableClicked(pointForPlayer,this.gameObject);
        }
    }

    public void DoAction()
    {
        switch (objects)
        {
            case TypeInterectuable.OBJECTS:

                switch (type)
                {
                    case TypeObject.ROCK:
                        Hide.SetActive(false);
                        imageRock.SetActive(true);

                        refScript.GetComponentInChildren<Inventory>().Rock = true;

                        break;
                    case TypeObject.BONE:

                        if (refScript.GetComponentInChildren<Inventory>().Rock == true)
                        {
                            if (!Taken)
                            {
                                imageBone.SetActive(true);
                                imageRock.SetActive(false);
                                refScript.GetComponentInChildren<Inventory>().Bone = true;
                                refScript.GetComponentInChildren<Inventory>().Rock = false;
                                Taken = true;
                            }
                        }

                        break;
                    case TypeObject.HAMMER:
                        Hide.SetActive(false);
                        imageHammer.SetActive(true);

                        refScript.GetComponentInChildren<Inventory>().Hammer = true;

                        break;
                    case TypeObject.STICK:
                        Hide.SetActive(false);
                        imageStick.SetActive(true);

                        refScript.GetComponentInChildren<Inventory>().Stick = true;

                        break;
                    default:
                        break;
                }

                break;
            case TypeInterectuable.MOVABLE:

                MoveObject();

                break;
            case TypeInterectuable.INTERACTUABLE:

                switch (use)
                {
                    case Uso.DOOR:
                        if (refScript.GetComponentInChildren<Inventory>().Bone == true)
                        {
                            imageBone.SetActive(false);
                            Hide.SetActive(false);
                            refScript.GetComponentInChildren<Inventory>().Bone = false;
                        }
                        break;
                    case Uso.WALL:

                        if (!Falled)
                        {
                            imageHammer.SetActive(false);
                            refScript.GetComponentInChildren<Inventory>().Hammer = false;
                            MoveObject();
                            Falled = true;
                        }

                        break;
                    case Uso.TRAMPILLAIZQUIERDA:
                        Player.transform.position = toRight.transform.position;
                        //Player.transform.Translate(toRight.position);
                        Debug.Log(toRight.transform.position);
                        Player.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
                        break;
                    case Uso.TRAMPILLADERECHA:
                        Player.transform.position = toLeft.transform.position;
                        //Player.transform.Translate(toLeft.position);
                        Player.GetComponent<NavMeshAgent>().SetDestination(Player.transform.position);
                        break;
                    case Uso.CALDERO:
                        if (refScript.GetComponentInChildren<Inventory>().Stick == true)
                        {
                            if (!Fired)
                            {
                                imageStick.SetActive(false);
                                imageTorch.SetActive(true);
                                refScript.GetComponentInChildren<Inventory>().Stick = false;
                                refScript.GetComponentInChildren<Inventory>().Torch = true;
                                Fired = true;
                            }
                        }

                        break;
                    case Uso.DESK:
                        if (refScript.GetComponentInChildren<Inventory>().Torch == true)
                        {
                            imageTorch.SetActive(false);
                            refScript.GetComponentInChildren<Inventory>().Torch = false;
                        }
                        break;
                    default:
                        break;
                }

                break;
            default:
                break;
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
