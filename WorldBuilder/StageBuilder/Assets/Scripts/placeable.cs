using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeable : MonoBehaviour
{
    //Collider myCollider;
    public Collider pCollider;
    public int codex = 0;
    public Color norm;
    public Renderer rend;
    public Vector3 Location;
    public Quaternion Rot;
    

    void Start()
    {  
        norm = rend.material.color;
    }
    public void GetLocalData()
    {
        Location = gameObject.transform.position;
        Rot = gameObject.transform.rotation;
    }

    public void ResetColor()
    {
        rend.material.color = norm;
    }
}
