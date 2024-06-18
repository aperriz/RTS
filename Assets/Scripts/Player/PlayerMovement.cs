using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] InputActionReference movement;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float maxSpeed = 5;

    public float currentSpeed = 0, deceleration = 100, acceleration = 50;
    public Vector2 oldMovementInput, MovementInput;

    //Hide in inspector
    [HideInInspector] public bool isSprinting;

    public void Sprint(InputAction.CallbackContext context)
    {
        if (!IsOwner) { return; }
        isSprinting = context.started || context.performed;
    }


    private void FixedUpdate()
    {
        if (!IsOwner)
        {
            return;
        }

        MovementInput = movement.action.ReadValue<Vector2>();

        //print(MovementInput);
        if (false/*playerMovement.paused*/)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if(isSprinting)
            {
                if (MovementInput.magnitude > 0 && currentSpeed >= 0)
                {
                    oldMovementInput = MovementInput;
                    currentSpeed += acceleration * maxSpeed * Time.deltaTime;
                }
                else
                {
                    currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
                }

                currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
                rb2d.velocity = oldMovementInput * currentSpeed;
            }
            else
            {
                if (MovementInput.magnitude > 0 && currentSpeed >= 0)
                {
                    oldMovementInput = MovementInput;
                    currentSpeed += acceleration * maxSpeed * Time.deltaTime * 2;
                }
                else
                {
                    currentSpeed -= deceleration * maxSpeed * Time.deltaTime * 2;
                }

                currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed * 2);
                rb2d.velocity = oldMovementInput * currentSpeed;
            }
        }

    }

    public override void OnNetworkSpawn()
    {
        if(!IsOwner) { return; }


    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) { return; }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.velocity = Vector2.zero;
    }
}
