using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroom : EnemyBase
{
    private FollowPath followPath;
    private SpriteRenderer SpriteRenderer;
    private Animator ani;

    public override void OnDie()
    {
        if (IsDie == true) return;

        IsDie = true;

        followPath.Stop();
        ani.SetTrigger("onDie");
    }

    void Start()
    {
        followPath = GetComponent<FollowPath>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ani = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        SpriteRenderer.flipX = followPath.Direction == 1 ? true : false;
        ani.SetFloat("moveSpeed", (int)followPath.State);
    }
}
