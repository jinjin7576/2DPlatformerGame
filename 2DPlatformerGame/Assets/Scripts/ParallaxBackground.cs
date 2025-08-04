using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BackgroundData
{
    public Renderer background;
    public float speed;
}

[SerializeField]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    Transform targetCamera;
    [SerializeField]
    BackgroundData[] backgrounds;
    [SerializeField]
    BackgroundData backgroundCloud;

    float targetStartX;

    private void Awake()
    {
        targetStartX = targetCamera.position.x;
    }


    void Update()
    {
        float cloudOffset = Time.time * backgroundCloud.speed;
        backgroundCloud.background.material.mainTextureOffset = new Vector2(cloudOffset, 0);

        if (targetCamera == null) return;

        float x = targetCamera.position.x - targetStartX;
        for (int i = 0; i < backgrounds.Length; ++i)
        {
            float offset = x * backgrounds[i].speed;
            backgrounds[i].background.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
