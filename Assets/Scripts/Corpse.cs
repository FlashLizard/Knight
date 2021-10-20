using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse :MonoBehaviour
{
    private void Start()
    {
        
    }
    public static void Create(AnimalId id, Vector3 poistion)
    {
        GameObject newCorpe = Data.Produce("Corpse", poistion);
        Data.FreshImage(newCorpe,"Corpses/"+id.ToString()+"Death");
        Debug.Log("Corpses/" + id.ToString() + "Death");
    }
    public static void Create(string name, Vector3 poistion)
    {
        GameObject newCorpe = Data.Produce("Corpse", poistion);
        Data.FreshImage(newCorpe, "Corpses/" + name + "Death");
    }
}
