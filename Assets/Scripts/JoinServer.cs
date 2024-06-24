using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

public class JoinServer : NetworkBehaviour
{

    private void Start()
    {
        if(Application.isEditor)
        {
            NetworkManager.Singleton.StartHost();
        }
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}
