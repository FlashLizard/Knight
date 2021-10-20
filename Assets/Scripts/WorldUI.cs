using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUI : MonoBehaviour
{
    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position);
    }
}
