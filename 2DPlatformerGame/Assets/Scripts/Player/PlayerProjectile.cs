using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private MovementRigidbody2D movement;
    private float originSpeed;

    public void SetUp(int direction)
    {
        movement = GetComponent<MovementRigidbody2D>();
        movement.MoveTo(direction);
        originSpeed = Mathf.Abs(movement.Velocity.x);
    }


    void Update()
    {
        if (movement.IsGrounded) movement.Jump();
        if (Mathf.Abs(movement.Velocity.x) < originSpeed)
        {
            Destroy(gameObject);
        }
    }
}
