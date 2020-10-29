using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float s;

    void FixedUpdate()
    {
        transform.eulerAngles += new Vector3(0, s, 0) * Time.fixedDeltaTime;
    }
}
