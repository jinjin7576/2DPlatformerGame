using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField]
    bool canBounce = false;
    float startPostionY;

    public bool IsHit { private set; get; } = false;
    private void Awake()
    {
        startPostionY = transform.position.y;
    }
    public virtual void UpdateCollision()
    {
        if (canBounce == true)
        {
            IsHit = true;
            StartCoroutine(nameof(OnBounce));
        }
    }

    private IEnumerator OnBounce()
    {
        float maxBounceAmount = 0.35f;

        yield return StartCoroutine(MoveToY(startPostionY, startPostionY + maxBounceAmount));

        yield return StartCoroutine(MoveToY(startPostionY + maxBounceAmount, startPostionY));
        IsHit = false;
    }

    private IEnumerator MoveToY(float start, float end)
    {
        float percent = 0;
        float bounceTime = 0.2f;

        while (percent < 1)
        {
            percent += Time.deltaTime / bounceTime;

            Vector3 position = transform.position;
            position.y = Mathf.Lerp(start, end, percent);
            transform.position = position;
            yield return null;
        }
    }
}
