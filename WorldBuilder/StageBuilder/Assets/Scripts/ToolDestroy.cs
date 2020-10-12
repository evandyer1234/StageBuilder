using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolDestroy : ToolBase
{
    
    protected Camera cam;
    

    
    public Color red;
    public Color norm;
    Color Original;
    GameObject last;
    GameObject current;
    bool first = true;

    void Start()
    {
        cam = GetComponent<Camera>();

    }
    public override void StartCommand()
    {
        first = true;
    }

    void FixedUpdate()
    {

        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(gameObject.transform.position);
        ray.direction = gameObject.transform.forward;


        if (Physics.Raycast(ray, out hit))
        {
            if (last != hit.collider.gameObject && last != null)
            {
                Renderer rend = hit.collider.gameObject.GetComponent<Renderer>();
                current = hit.collider.gameObject;
                Renderer rend2 = last.GetComponent<Renderer>();

                if (rend2 != null && last != null)
                {
                    rend2.material.color = Original;
                }
                if (rend != null)
                {
                    Original = rend.material.color;
                    rend.material.color = red;                   
                }
            }
           
            if (Input.GetMouseButtonDown(0))
            {
                MouseButton();
            }
            last = hit.collider.gameObject;
        }
        
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
                Destroy(hit.collider.transform.parent.gameObject);
            }
            else
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
    public virtual void selected()
    {

    }
    public override void EndCommand()
    {
        Renderer rend = current.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Original;
        }
    }
}
    

