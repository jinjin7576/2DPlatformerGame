using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField]
    private LayerMask groundCheckLayer; //�ٴ� üũ
    [SerializeField]
    private LayerMask aboveCollisionLayer; //�Ӹ��� �浹
    [SerializeField]
    private LayerMask belowCollisionLayer; //�� �浹 üũ

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

    float hangTime = 0.2f;
    float hangCounter;

    Vector2 collisionSize;
    Vector2 footPostion;
    Vector2 headPosition;

    Rigidbody2D rigid2D;
    Collider2D collider2D;

    public Vector3 Velocity => rigid2D.velocity;
    public Collider2D HitAboveObject { private set; get; } //�Ӹ��� �浹�� ������Ʈ ����
    public Collider2D HitBelowObject { private set; get; } //�߿� �浹�� ������Ʈ ����
    public bool IsLongJump { get; set; } = false;
    public bool IsGrounded {  get; private set; } = false;

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
        footPostion = new Vector2(bounds.center.x, bounds.min.y); //�� ��ġ
        headPosition = new Vector2(bounds.center.x, bounds.max.y);//�Ӹ� ��ġ

        IsGrounded = Physics2D.OverlapBox(footPostion, collisionSize, 0, groundCheckLayer); //�浹�Ǿ������� üũ
        HitAboveObject = Physics2D.OverlapBox(headPosition, collisionSize, 0, aboveCollisionLayer); //�Ӹ��� �浹�� �浹ü ���� ����
        HitBelowObject = Physics2D.OverlapBox(footPostion, collisionSize, 0, belowCollisionLayer); //�߿� �浹
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

        if(IsGrounded == true) jumpBufferCounter = jumpBufferTime;
    }
    private void JumpAdditive()
    {
        if (IsGrounded) hangCounter = hangTime;
        else            hangCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0) jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0 && hangCounter >0 )
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            jumpBufferCounter = 0;
            hangCounter = 0;
        }
    }
    public void RestVelocityY()
    {
        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
    }
    

}
