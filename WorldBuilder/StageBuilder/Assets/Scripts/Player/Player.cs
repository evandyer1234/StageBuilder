using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float spinspeed = 60f;
    public float jumpforce = 100f;
    public Vector3 spawnpoint = new Vector3(0, 0, 0);
    Rigidbody rb;
    public float bottom = -5f;
    public bool grounded = false;

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
        Vector3 location = rb.position;

        location += (s * Time.fixedDeltaTime * transform.forward);


        rb.position = location;
    }
    public void MoveLeft(float s)
    {
        transform.eulerAngles += new Vector3(0, s, 0) * Time.fixedDeltaTime;
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
