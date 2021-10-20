using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = Data.Player.transform;
    }
}
