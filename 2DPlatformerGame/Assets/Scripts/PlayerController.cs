using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    KeyCode jumpKeyCode = KeyCode.C;
    MovementRigidbody2D movement;
    void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        x *= offset;

        UpdateMove(x);
        UpdateJump();
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement.Jump();
        }
        if (Input.GetKey(jumpKeyCode))
        {
            movement.IsLongJump = true;
        }
        if (Input.GetKeyUp(jumpKeyCode))
        {
            movement.IsLongJump = false;
        }
    }

    private void UpdateMove(float x)
    {
        movement.MoveTo(x);
    }
}
