using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolManager : MonoBehaviour
{    
    public GameObject cam;
    ItemPlacer IP;
    ToolDestroy TD;
    ToolRotate TR;
    public int listindex = 0;
    public int tools = 2;
    public TextMeshProUGUI mode;
    public GameObject circle;
    
    void Start()
    {
        circle.SetActive(false);
        tools--;
        mode.text = "Mode: Build";
        TD = cam.gameObject.GetComponent<ToolDestroy>();
        IP = cam.gameObject.GetComponent<ItemPlacer>();
        TR = cam.gameObject.GetComponent<ToolRotate>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToolSwap();                
        }               
    }

    public void ToolSwap()
    {
        
        if (listindex + 1 <= tools)
        {          
            listindex++;           
        }
        else
        {            
            listindex = 0;           
        }
        
        if (listindex == 0)
        {
            circle.SetActive(false);
            TR.EndCommand();
            TR.enabled = false;
            IP.enabled = true;
            IP.StartCommand();
            mode.text = "Mode: Build";
        }
        else if (listindex == 1)
        {
            circle.SetActive(true);
            IP.EndCommand();
            IP.enabled = false;
            TD.enabled = true;
            TD.StartCommand();
            mode.text = "Mode: Destroy";
        }
        else if (listindex == 2)
        {
            TD.EndCommand();
            TD.enabled = false;
            TR.enabled = true;
            TR.StartCommand();
            mode.text = "Mode: Rotate";
        }
    }
}
