using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private UIPlayerData uiPlayerData;

    [SerializeField]
    private int max = 3;
    [SerializeField]
    private int current;

    private SpriteRenderer SpriteRenderer;
    private PlayerController playerController;
    private Color originColor;

    [SerializeField]
    private float invincibilityTime = 0;
    private bool isInvincibility = false;
    private void Awake()
    {
        current = max;
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
        originColor = SpriteRenderer.color;
    }

    public void DecreaseHP()
    {
        if (isInvincibility == true) return;

        OnInvincibility(1f);

        if (current > 1)
        {
            current--;
            uiPlayerData.SetHp(current, false);
        }
        else
        {
            playerController.OnDie();
        }
    }
    public void IncreaseHP()
    {
        if (current < max)
        {
            uiPlayerData.SetHp(current, true);
            current++;
        }
    }

    public void OnInvincibility(float time)
    {
        if (isInvincibility)
        {
            invincibilityTime += time;
        }
        else
        {
            invincibilityTime = time;

            StartCoroutine(nameof(Invincibility));
        }
    }

    private IEnumerator Invincibility()
    {
        isInvincibility = true;

        float blinkSpeed = 10;
        while ( invincibilityTime >= 0)
        {
            invincibilityTime -= Time.deltaTime;
            Color color = SpriteRenderer.color;
            color.a = Mathf.SmoothStep(0, 1, Mathf.PingPong(Time.time * blinkSpeed, 1));
            SpriteRenderer.color = color;

            yield return null;
        }
        SpriteRenderer.color = originColor;
        isInvincibility = false;
    }
}
