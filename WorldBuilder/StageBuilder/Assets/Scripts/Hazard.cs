using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
        {
            p.Respawn();
        }
    }
}
