using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] InputActionReference movement, sprint;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float maxSpeed = 5;

    public float currentSpeed = 0, deceleration = 100, acceleration = 50;
    public Vector2 oldMovementInput, MovementInput;
    private bool paused = false;

    //Hide in inspector
    [HideInInspector] public bool isSprinting;

    public void Sprint(InputAction.CallbackContext context)
    {
        if (!IsOwner) { return; }
        isSprinting = context.started || context.performed;
        Debug.Log("Sprinting");
    }


    private void FixedUpdate()
    {
        if (!IsOwner)
        {
            return;
        }

        MovementInput = movement.action.ReadValue<Vector2>();

        //print(MovementInput);
        if (paused)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            if (sprint.action.ReadValue<float>() > 0f) { maxSpeed = 10; } else { maxSpeed = 5; }

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

    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { return; }


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
