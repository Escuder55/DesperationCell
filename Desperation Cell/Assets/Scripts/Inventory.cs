using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Rock;
    public bool Bone;
    public bool Hammer;
    public bool Stick;
    public bool Torch;

    void Start()
    {
        Rock = false;
        Bone = false;
        Hammer = false;
        Stick = false;
        Torch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
