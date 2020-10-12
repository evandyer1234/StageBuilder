using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable()]
public class SaveData
{
    public List<DataStruct> DataStructList;

    public SaveData()
    {
        DataStructList = new List<DataStruct>();
    }

    public void AddData(int n, Vector3 l, Quaternion r)
    {
        DataStructList.Add(new DataStruct(n, l, r));
    }
}
