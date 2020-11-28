using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float spinspeed = 60f;
    public float jumpforce = 100f;
    public float rotrate = 0.1f;

    public Vector3 spawnpoint = new Vector3(0, 0, 0);
       
    public float bottom = -5f;
    public bool grounded = false;
    public DynamicCam cam;
    public GameObject camturn;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            cam.gameObject.transform.SetParent(cam.center.transform);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            cam.gameObject.transform.SetParent(null);
        }
    }
    void FixedUpdate()
    {
        /*
        if (gameObject.transform.position.y < bottom)
        {
            Respawn();
        }
        */
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward(MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveForward(-MoveSpeed);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(-spinspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveLeft(spinspeed);
        }
        
    }
    public void Respawn()
    {
        gameObject.transform.position = spawnpoint;
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void MoveForward(float s)
    {
        Vector3 dir = cam.endtrans.transform.forward;
        dir.y = 0;

        Vector3 location = rb.position;
        //transform.forward = dir;
        camturn.transform.forward = dir;
        transform.rotation = Quaternion.Slerp(transform.rotation, camturn.transform.rotation, rotrate);
        
        location += (s * Time.fixedDeltaTime * dir);
        

        rb.position = location;
    }
    public void MoveLeft(float s)
    {
        
        cam.center.transform.eulerAngles += new Vector3(0, s, 0) * Time.fixedDeltaTime;
    }
    public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            rb.AddForce(transform.up * jumpforce);
        }
    }
}
