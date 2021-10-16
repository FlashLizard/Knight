using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipData
{
    private string _name;
    private EquipType _type;
    private EquipQuality _quality;
    private float _interval;
    private EquipId _id;
    private int _demage, _depletion;

    public string Name { get => _name; set => _name = value; }
    public EquipType Type { get => _type; set => _type = value; }
    public EquipQuality Quality { get => _quality; set => _quality = value; }
    public float Interval { get => _interval; set => _interval = value; }
    public EquipId Id { get => _id; set => _id = value; }
    public int Demage { get => _demage; set => _demage = value; }
    public int Depletion { get => _depletion; set => _depletion = value; }

    public EquipData(EquipId id,string name, EquipType type, EquipQuality quality, int demage,int depletion,float interval)
    {
        this.Id = id;
        this.Name = name;
        this.Type = type;
        this.Quality = quality;
        this.Interval = interval;
        this.Demage = demage;
        this.Depletion = depletion;
    }
    public abstract void Attack(GameObject Hand, Vector2 derection);
}
