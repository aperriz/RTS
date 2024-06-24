using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public GameObject cameraHolder;

    private void Start()
    {
        if (IsOwner)
        {
            cameraHolder.SetActive(true);
            cameraHolder.AddComponent<SelectionController>();
        }

    }
}
