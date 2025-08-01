using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField]
    private LayerMask groundCheckLayer;

    [Header("Move")]
    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 8;

    [Header("Jump")]
    [SerializeField]
    float jumpForce = 13;
    [SerializeField]
    float lowGravityScale = 2;
    [SerializeField]
    float highGravityScale = 3.5f;

    float moveSpeed;

    //�ٴڿ� ���� ���� ���� ���� ���� Ű�� ������ �� �����ϸ� �ٷ� ������ �ǵ���(���Է�)
    float jumpBufferTime = 0.1f;
    float jumpBufferCounter;

    Vector2 collisionSize;
    Vector2 footPostion;

    Rigidbody2D rigid2D;
    Collider2D collider2D;

    public bool IsLongJump { get; set; } = false;
    public bool IsGrounded { get; set; } = false;

    private void Awake()
    {
        moveSpeed = walkSpeed;

        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        UpdateCollision();
        JumpHeight();
        JumpAdditive();
    }

    

    public void MoveTo(float x)
    {
        moveSpeed = Mathf.Abs(x) != 1 ? walkSpeed : runSpeed;
        if (x != 0)
        {
            x = MathF.Sign(x);
        }
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }
    private void UpdateCollision()
    {
        Bounds bounds = collider2D.bounds;
        collisionSize = new Vector2((bounds.max.x - bounds.min.x) * 0.5f, 0.1f); //�÷��̾� �߿� �����ϴ� �浹 ����
        footPostion = new Vector2(bounds.center.x, bounds.min.y);
        IsGrounded = Physics2D.OverlapBox(footPostion, collisionSize, 0, groundCheckLayer); //�浹�Ǿ������� üũ
    }

    private void JumpHeight()
    {
        if (IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravityScale;
        }
        else
        {
            rigid2D.gravityScale = highGravityScale;
        }
    }
    public void Jump()
    {
        /*
        if (IsGrounded == true)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
        }
        */
        jumpBufferCounter = jumpBufferTime;
    }
    private void JumpAdditive()
    {
        if (jumpBufferCounter > 0) jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            jumpBufferCounter = 0;
        }
    }
}
