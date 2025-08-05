using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RespawnType { AfterTime = 0, PlayerDead }
public class PlatformDrop : PlatformBase
{
    [SerializeField]
    RespawnType respawnType = RespawnType.AfterTime;
    [SerializeField]
    float respawnTime = 2;

    BoxCollider2D boxCollider2D;
    Rigidbody2D rigid2D;
    Vector3 originPosition;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigid2D = GetComponent<Rigidbody2D>();
        originPosition = transform.position;
    }

    public override void UpdateCollision(GameObject other)
    {
        if (IsHit == true) return;

        IsHit = true;

        StartCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        yield return StartCoroutine(nameof(OnShake));

        OnDrop();
        if ( respawnType == RespawnType.AfterTime)
        {
            StartCoroutine(nameof(OnRespawn));
        }
        else
        {
            Destroy(gameObject, respawnTime);
        }
    }

    private IEnumerator OnRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        IsHit = false;

        transform.position = originPosition;
        boxCollider2D.enabled = true;
        rigid2D.isKinematic = true;
        rigid2D.velocity = Vector2.zero;
    }

    private void OnDrop()
    {
        rigid2D.isKinematic = false;
        boxCollider2D.enabled = false;
    }

    private IEnumerator OnShake()
    {
        float percent = 0;
        float shakeAngle = 5;
        float shakeSpeed = 10;
        float shakeTime = 1.5f;

        while(percent < 1)
        {
            percent += Time.deltaTime / shakeTime;
            float z = Mathf.Lerp(-shakeAngle, shakeAngle, Mathf.PingPong(Time.time * shakeSpeed, 1));
            transform.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        transform.rotation = Quaternion.identity;
    }
}
