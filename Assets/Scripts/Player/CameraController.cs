using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : NetworkBehaviour
{
    public Camera cameraHolder;
    public AudioListener audioListener;
    public Physics2DRaycaster physics2DRaycaster;

    private void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, -1);
        if (IsOwner)
        {
            cameraHolder.enabled = true;
            audioListener.enabled = true;
            physics2DRaycaster.enabled = true;
            //cameraHolder.AddComponent<SelectionController>();
        }

    }
}
