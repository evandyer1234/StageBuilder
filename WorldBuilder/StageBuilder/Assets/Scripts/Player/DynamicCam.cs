using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    public GameObject target;
    public float distance = 3f;
    Vector3 MoveDirection;
    public float speed = 10f;

    void Awake()
    {
        gameObject.transform.SetParent(null);
    }

   
    void FixedUpdate()
    {       
        if (Vector3.Distance(target.gameObject.transform.position, transform.position) > distance)
        {
            Vector3 dir = transform.forward;
            dir.y = 0;

            Vector3 location = gameObject.transform.position;

            location += (speed * Time.fixedDeltaTime * dir);
            gameObject.transform.position = location;
        }
    }
    void Update()
    {
        MoveDirection = (target.gameObject.transform.position - transform.position).normalized;
        gameObject.transform.forward = MoveDirection;
    }
}
