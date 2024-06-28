using Unity.Netcode;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    static GameManager instance;
    public static List<GameObject> activeCameras = new();
    public static List<CameraController> cameraControllers = new();
    public static HashSet<Selectable> globalUnits = new();

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
}