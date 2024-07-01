using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : Selectable
{
    [SerializeField]
    CircleCollider2D attackZone;
    [SerializeField] float attackRadius = 1f;
    [SerializeField] AIDestinationSetter destinationSetter;
    GameObject target;

    private void Awake()
    {
        
        
        
    }

    private void Start()
    {
        attackZone.radius = attackRadius;
    }

    public override void Move(Vector2 dest)
    {
        if(target != null) { Destroy(target); }

        target = new GameObject();

        destinationSetter.target = target.transform;

        destinationSetter.target.position = dest;
    }


}
