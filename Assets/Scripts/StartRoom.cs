using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoom :MonoBehaviour
{
    [SerializeField]
    GameObject shop;

    private void Start()
    {
        if (Random.value < 0.75) Destroy(shop);
    }
}
