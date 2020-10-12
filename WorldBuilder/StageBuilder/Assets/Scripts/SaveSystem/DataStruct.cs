using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable()]
public class DataStruct
{
    public int number;
    public Vector3 Location;
    public Quaternion Rot;

    public DataStruct()
    { }

    public DataStruct(int n, Vector3 l, Quaternion r)
    {
        number = n;
        Location = l;
        Rot = r;
    }

    public override string ToString()
    {
        return "N:" + number + "|| L:" + Location.ToString() + "|| R:" + Rot.ToString();
    }
}
