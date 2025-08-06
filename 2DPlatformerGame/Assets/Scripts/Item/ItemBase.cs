using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnForce = new Vector2(1, 7);
    [SerializeField]
    private float aliveTimeAfterSpawn = 5;

    private bool allowCollect = true;
    
    public void Setup()
    {
        StartCoroutine(nameof(SpawnItemPrcess));
    }
    IEnumerator SpawnItemPrcess()
    {
        allowCollect = false;

        var rigid = gameObject.AddComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        rigid.velocity = new Vector2(Random.Range(-spawnForce.x, spawnForce.x), spawnForce.y);

        while(rigid.velocity.y > 0)
        {
            yield return null;
        }

        allowCollect = true;
        GetComponent<Collider2D>().isTrigger = false;

        yield return new WaitForSeconds(aliveTimeAfterSpawn);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (allowCollect && collision.CompareTag("Player"))
        {
            UpdateCollison(collision.transform);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (allowCollect && collision.transform.CompareTag("Player"))
        {
            UpdateCollison(collision.transform);
            Destroy(gameObject);
        }
    }

    public abstract void UpdateCollison(Transform target);
}
