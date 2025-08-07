using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : EnemyBase
{
    [SerializeField]
    private LayerMask groundLayer;

    private MovementRigidbody2D movement2D;
    private new Collider2D collider2D;
    private Animator ani;
    private SpriteRenderer SpriteRenderer;
    private int direction = -1;

    private void Awake()
    {
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ani = GetComponentInChildren<Animator>();
        movement2D = GetComponent<MovementRigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        StartCoroutine(nameof(Idle));
    }

    public override void OnDie()
    {
        if (IsDie == true) return;

        IsDie = true;

        StopAllCoroutines();

        float destroyTime = 2f;
        StartCoroutine(FadeEffect.Fade(SpriteRenderer, 1, 0, destroyTime));
        Destroy(gameObject, destroyTime);
    }

    private IEnumerator Idle()
    {
        float waitTime = 2;
        float time = 0;
        while (time < waitTime)
        {
            time += Time.deltaTime;

            yield return null;
        }

        movement2D.Jump();
        ani.SetTrigger("onJump");

        StartCoroutine(nameof(Jump));
    }
    private IEnumerator Jump()
    {
        yield return new WaitUntil(() => !movement2D.IsGrounded);

        while (true)
        {
            UpdateDirection();
            movement2D.MoveTo(direction);
            ani.SetFloat("VelocityY", movement2D.Velocity.y);

            if (movement2D.IsGrounded)
            {
                movement2D.MoveTo(0);
                ani.SetTrigger("onLanding");

                StartCoroutine(nameof(Idle));

                yield break;
            }
        }
    }

    private void UpdateDirection()
    {
        Bounds bound = collider2D.bounds;
        Vector2 size = new Vector2(0.1f, (bound.max.y - bound.min.y) * 0.8f);
        Vector2 position = new Vector2(direction == -1 ? bound.min.x : bound.max.x, bound.center.y);

        if (Physics2D.OverlapBox(position, size , 0 , groundLayer))
        {
            direction *= -1;
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }
    }
}
