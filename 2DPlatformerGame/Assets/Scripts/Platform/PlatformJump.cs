using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : PlatformBase
{
    [SerializeField]
    private float jumpForce = 22;
    [SerializeField]
    private float resetTime = 0.5f;

    private Animator ani;
    private GameObject other;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    public override void UpdateCollision(GameObject other)
    {
        if (IsHit == true) return;
        IsHit = true;
        this.other = other;

        ani.SetTrigger("OnJump");
    }
    public void JumpAction()
    {
        other.GetComponent<MovementRigidbody2D>().JumpTo(jumpForce);
        other = null;

        Invoke(nameof(Reset), resetTime);
    }

    private void Reset()
    {
        IsHit = false;
    }
}
