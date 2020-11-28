using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    public GameObject target;
    public GameObject center;
    public GameObject endtrans;

    Vector3 MoveDirection;
    public Vector2 campos = new Vector2(3.5f, 4.5f);

    public float distance = 3f;    
    public float speed = 10f;   
    public float rotrate = 0.1f;
    public float downrate = 0.1f;

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
        endtrans.transform.forward = MoveDirection;

        transform.rotation = Quaternion.Slerp(transform.rotation, endtrans.transform.rotation, rotrate);

        
        if (transform.position.y - target.transform.position.y > campos.y)
        {
            transform.position -= new Vector3(0, downrate, 0);
            //transform.position -= new Vector3(0, (transform.position.y - target.transform.position.y - campos.y), 0);
        }
        else if(transform.position.y - target.transform.position.y < campos.x)
        {
            transform.position += new Vector3(0, downrate, 0);
            //transform.position += new Vector3(0, (transform.position.y - target.transform.position.y - campos.x), 0);
        }
        

    }
}
