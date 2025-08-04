using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator ani;
    MovementRigidbody2D movement;

    void Start()
    {
        ani = GetComponent<Animator>();
        movement = GetComponentInParent<MovementRigidbody2D>();
    }

    public void UpdateAnimation(float x)
    {
        if (x != 0)
        {
            SpriteFlipX(x);
        }

        ani.SetBool("Jump", !movement.IsGrounded);

        if (movement.IsGrounded)
        {
            ani.SetFloat("Velocity x", MathF.Abs(x));
        }
        else
        {
            ani.SetFloat("Velocity y", movement.Velocity.y);
        }
    }

    private void SpriteFlipX(float x)
    {
        transform.parent.localScale = new Vector3((x < 0 ? -1 : 1), 1, 1);
    }
}
