using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    public GameObject Target;
    void Awake()
    {
        gameObject.transform.SetParent(null);
    }

    
    void Update()
    {
        transform.position = Target.transform.position;
    }
}
