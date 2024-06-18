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

    [SerializeField] Player owner;

    private void Awake()
    {
        hitbox.size = new Vector2(hitboxSize, hitboxSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
