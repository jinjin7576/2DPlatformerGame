using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    StageData stageData;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    KeyCode jumpKeyCode = KeyCode.C;
    [SerializeField]
    KeyCode fireKeyCode = KeyCode.Z;
    MovementRigidbody2D movement;
    PlayerAnimator playerAnimator;
    PlayerWeapon weapon;
    PlayerData playerData;

    private int lastDirectionX = 1; 
    void Awake()
    {
        movement = GetComponent<MovementRigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
        weapon = GetComponent<PlayerWeapon>();
        playerData = GetComponent<PlayerData>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float offset = 0.5f + Input.GetAxisRaw("Sprint") * 0.5f;
        if (x != 0) lastDirectionX = (int) x;
        x *= offset;

        UpdateMove(x);
        UpdateJump();
        UpdateRangeFire();
        playerAnimator.UpdateAnimation(x);
        UpdateAboveCollision();
        UpdateBelowCollision();
        isUnderGround();
    }

    private void isUnderGround()
    {
        if (transform.position.y < stageData.MapLimitMinY)
        {
            OnDie();
        }
    }

    public void OnDie()
    {
        gameController.LevelFailed();
    }

    private void UpdateBelowCollision()
    {
        if (movement.HitBelowObject != null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && movement.HitBelowObject.TryGetComponent<PlatformEffectorExtension>(out var p))
            {
                p.OnDownWay();
            }
            if (movement.HitBelowObject.TryGetComponent<PlatformBase>(out var platform))
            {
                platform.UpdateCollision(gameObject);
            }
        }
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
    
    private void UpdateRangeFire()
    {
        if (Input.GetKeyDown(fireKeyCode) && playerData.CurrentProjectile > 0)
        {
            playerData.CurrentProjectile--;
            weapon.StartFire(lastDirectionX);
        }
    }
    public void LevelComplete()
    {
        gameController.LevelComplete();
    }
    public void SetUp(StageData stageData)
    {
        this.stageData = stageData;
        transform.position = this.stageData.PlayerPosition;
    }

}
