using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;

public class Controllable : Selectable
{
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    BoxCollider2D hitbox;

    public int health = 10;
    public float hitboxSize = 1f;

    NetworkObject owner;
    SelectionController selection;

    private void Awake()
    {
        hitbox.size = new Vector2(hitboxSize, hitboxSize);

        Debug.Log(_ownerIds);
        Debug.Log(OwnerClientId);
    }

    private bool SetOwner()
    {
        try
        {
            owner = NetworkManager.Singleton.ConnectedClients[OwnerClientId - 1].PlayerObject;

            if (owner != null)
            {
                selection = owner.GetComponentInChildren<SelectionController>();
            }
            return true;
        }
        catch { return false; }
    }
}
