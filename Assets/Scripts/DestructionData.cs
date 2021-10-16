using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionData
{
    private string _name;
    private int _health;

    public string Name { get => _name; set => _name = value; }
    public int Health { get => _health; set => _health = value; }

    public DestructionData(string name,int health)
    {
        this.Name = name;
        this.Health = health;
    }
}
