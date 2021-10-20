using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionData
{
    private int _health;

    public int Health { get => _health; set => _health = value; }

    public DestructionData(string name,int health)
    {
        this.Health = health;
    }
}
