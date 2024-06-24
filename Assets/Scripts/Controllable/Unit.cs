using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : Selectable
{
    [SerializeField]
    CircleCollider2D attackZone;
    [SerializeField] float attackRadius = 1f;

    private void Awake()
    {
        attackZone.radius = attackRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
