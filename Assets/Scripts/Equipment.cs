using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    int _id;


    public int Id { get => _id<0?0:_id; set => _id = value; }

    public static string GetImage()
    {
        return "";
    }
    public static string GetName()
    {
        return "";
    }
}
