using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolRotate : ToolDestroy
{
    public float speed = 20f;
    public GameObject Selection;
    bool selecting = false;


    void Update()
    {
        selected();
    }
    public override void MouseButton()
    {
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(gameObject.transform.position);
        ray.direction = gameObject.transform.forward;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.transform.parent.gameObject != null)
            {
                Selection = hit.collider.transform.parent.gameObject;
                selecting = true;
            }
            else if (hit.collider.gameObject != null)
            {
                Selection = hit.collider.gameObject;
                selecting = true;
            }
        }
    }
    public override void selected()
    {
        if (selecting)
        {
            if (Selection != null)
            {
                /*
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(Selection.transform.rotation.x + speed * Time.fixedDeltaTime, Selection.transform.rotation.y, Selection.transform.rotation.z);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(Selection.transform.rotation.x + -speed * Time.fixedDeltaTime, Selection.transform.rotation.y, Selection.transform.rotation.z);
                }
                */
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(-speed * Time.fixedDeltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(0, speed * Time.fixedDeltaTime, 0);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Selection.transform.localEulerAngles += new Vector3(0,-speed * Time.fixedDeltaTime, 0);
                }
            }
        }
    }
    
}
