using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public GameObject cameraHolder;

    private void Start()
    {
        if (IsOwner)
        {
            cameraHolder.SetActive(true);
        }
    }

    private void Update()
    {
        cameraHolder.transform.position = transform.position;
    }
}
