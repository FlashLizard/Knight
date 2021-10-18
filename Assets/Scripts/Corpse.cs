using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse :MonoBehaviour
{
    public static void Create(AnimalId id, Vector2 poistion)
    {
        GameObject newCorpe = Data.Produce("CorpseSample", poistion);
        Data.FreshImage(newCorpe,"Corpses/"+id.ToString()+"Death");
    }
}
