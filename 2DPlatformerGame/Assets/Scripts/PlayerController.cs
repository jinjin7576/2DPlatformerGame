using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    StageData stageData;

    [SerializeField]
    KeyCode jumpKeyCode = KeyCode.C;
    MovementRigidbody2D movement;
    PlayerAnimator playerAnimator;
    void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;

        x *= offset;

        UpdateMove(x);
        UpdateJump();
        playerAnimator.UpdateAnimation(x);
        UpdateAboveCollision();
    }

    private void UpdateAboveCollision()
    {
        if (movement.Velocity.y >= 0 && movement.HitAboveObject != null)
        {
            movement.RestVelocityY();
            if (movement.HitAboveObject.TryGetComponent<TileBase>(out var tile) && !tile.IsHit)
            {
                tile.UpdateCollision();
            }
        }
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
        float xPosition = Mathf.Clamp(transform.position.x, stageData.PlayerLimitMinX, stageData.PlayerLimITMaxX);
        transform.position = new Vector2(xPosition, transform.position.y);


    }
}
