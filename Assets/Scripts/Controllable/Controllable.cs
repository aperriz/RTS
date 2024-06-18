using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;

public class Controllable : NetworkBehaviour
{
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    BoxCollider2D hitbox;

    [SerializeField] public int health = 10;
    [SerializeField] public float hitboxSize = 1f;
    [SerializeField] public ulong OwnerId = 0;

    NetworkObject owner;
    SelectionController selection;

    private void Awake()
    {
        hitbox.size = new Vector2(hitboxSize, hitboxSize);

        Debug.Log(OwnerId);
        Debug.Log(OwnerClientId);
    }

    public void Select()
    {
        if (OwnerId == OwnerClientId)
        {
            if(SetOwner()) selection.OverwriteSelect(this);
        }
    }

    private bool SetOwner()
    {
        try
        {
            owner = NetworkManager.Singleton.ConnectedClients[OwnerClientId - 1].PlayerObject;

            if (owner != null)
            {
                selection = owner.GetComponent<SelectionController>();
            }
            return true;
        }
        catch { return false; }
    }
}
