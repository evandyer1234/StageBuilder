using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    Camera cam;
    public float speed = 5f;
    public float MouseSen = 300f;

    public float freeLookSens = 2.5f;
    public Transform playerBody;
    public float XRotate = 0f;
    public Manager manager;
    public GameObject main;
    public GameObject contr;
    bool con = false;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {      
        float nRotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSens;
        float nRotY = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * -freeLookSens;
        transform.localEulerAngles = new Vector3(nRotY, nRotX, 0f);

        if(Input.GetKeyDown(KeyCode.P))
        {
            manager.SaveTheData();
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            manager.LoadTheData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (con)
            {
                main.SetActive(false);
                contr.SetActive(true);
            }
            else
            {
                main.SetActive(true);
                contr.SetActive(false);
            }
            con = !con;             
        }
    }
   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward(speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            forward(-speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            sideways(-speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            sideways(speed);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vertical(-speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vertical(speed);
        }

    }
    public void forward(float speed)
    {
        Vector3 location = gameObject.transform.position;

        location += (speed * Time.fixedDeltaTime * transform.forward);
        gameObject.transform.position = location;
    }
    public void sideways(float speed)
    {
        Vector3 location = gameObject.transform.position;

        location += (speed * Time.fixedDeltaTime * transform.right);
        gameObject.transform.position = location;
    }
    public void Vertical(float speed)
    {
        Vector3 location = gameObject.transform.position;

        location += (speed * Time.fixedDeltaTime * transform.up);
        gameObject.transform.position = location;
    }
}
