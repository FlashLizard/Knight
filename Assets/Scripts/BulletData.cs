using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData
{
    private string _name;
    private float _radius;

    public string Name { get => _name; set => _name = value; }
    public float Radius { get => _radius; set => _radius = value; }

    public BulletData(string name, float radius)
    {
        this.Name = name;
        this.Radius = radius;
    }
}
