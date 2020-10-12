using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public Player p;

    void OnTriggerEnter(Collider collision)
    {
        p.grounded = true;
    }
    void OnTriggerExit(Collider collision)
    {
        p.grounded = false;
    }
}
