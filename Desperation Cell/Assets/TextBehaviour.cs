using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    public enum TextType
    {
        NONE,
        NOTHING_INSIDE,
        NOT_READY_TO_INTERACT,
        GET_OBJECT
    };

    [SerializeField] TextType type;
    [SerializeField] GameObject canvas;
    [SerializeField] Text text;
    [SerializeField] float timeShowingText = 3;

    [Header("OBJECT")]
    [SerializeField] string _object;
    [Header("NOT READY")]
    [SerializeField] string textNotReady;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (type)
            {
                case TextType.NONE:
                    break;
                case TextType.NOTHING_INSIDE:
                    {
                        text.text = "NO HAY NADA INTERESANTE";
                        canvas.SetActive(true);
                        Invoke("DeactivateText", 5);
                        break;
                    }
                case TextType.NOT_READY_TO_INTERACT:
                    {
                        text.text = textNotReady;
                        canvas.SetActive(true);
                        Invoke("DeactivateText", 5);
                        break;
                    }
                case TextType.GET_OBJECT:
                    {
                        text.text = "HAS RECOGIDO EL SIGUIENTE OJECTO: " + _object;
                        canvas.SetActive(true);
                        Invoke("DeactivateText", timeShowingText);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    void DeactivateText()
    {
        canvas.SetActive(false);
    }

}
