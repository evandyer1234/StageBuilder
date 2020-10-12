using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : ToolBase
{
    Camera cam;
    public GameObject current;
    
    public List<GameObject> objects = new List<GameObject>();
    public List<placeable> ghosts = new List<placeable>();
    public int listindex = 0;
    bool hitting = false;

    void Start()
    {
        cam = GetComponent<Camera>();
        StartCommand();
    }

    public override void StartCommand()
    {
        ghosts[0].gameObject.SetActive(true);
        listindex = 0;
        current = ghosts[0].gameObject;
    }
    void FixedUpdate()
    {
       
        RaycastHit hit;
        
        Ray ray = cam.ScreenPointToRay(gameObject.transform.position);
        ray.direction = gameObject.transform.forward;
       

        if (Physics.Raycast(ray, out hit))
        {
            if (gameObject.transform.eulerAngles.x <= 0)
            {
                ghosts[listindex].transform.eulerAngles = new Vector3(180, 0, 0);
            }
            else
            {
                ghosts[listindex].transform.eulerAngles = new Vector3(0, 0, 0);
            }
            ghosts[listindex].transform.position = hit.point;
            ghosts[listindex].pCollider.enabled = false;
            if (hit.collider.gameObject == null)
            {
                hitting = false;
            }
            else
            {
                hitting = true;
            }
            
        }      
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ObjectSwap();
        }
        if (Input.GetMouseButtonDown(0) && hitting)
        {
            MouseButton();
        }
    }
    public override void MouseButton()
    {
        RaycastHit hit;
        
        Ray ray = cam.ScreenPointToRay(gameObject.transform.position);
        ray.direction = gameObject.transform.forward;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject clone;
            clone = Instantiate(objects[listindex], new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
        }
    }
    public void ObjectSwap()
    {
        ghosts[listindex].gameObject.SetActive(false);
        if (listindex + 1 < ghosts.Capacity)
        {
            listindex++;
        }
        else
        {
            listindex = 0;
        }
        ghosts[listindex].gameObject.SetActive(true);
    }
    public override void EndCommand()
    {
        ghosts[listindex].gameObject.SetActive(false);
    }
}
