using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeList : MonoBehaviour
{
    
    Manager manager;

    void Start()
    {
        manager = GetComponent<Manager>();
    }
    
    public void addobjects()
    {
        manager.objectlist.Clear();
        manager.objectlist.Capacity = 0;
        Debug.Log("AddObjects called");
        foreach (placeable p in FindObjectsOfType<placeable>())
        {
            p.GetLocalData();
            Debug.Log("Loop called");
            manager.objectlist.Capacity++;
            Debug.Log("capactiy increased");
            manager.objectlist.Add(p.gameObject);
            Debug.Log("object added");
        }
    }

}
