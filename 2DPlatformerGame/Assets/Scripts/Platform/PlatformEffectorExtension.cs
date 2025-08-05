using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffectorExtension : MonoBehaviour
{
    private PlatformEffector2D effector;

    private void Awake()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    
    public void OnDownWay()
    {
        StartCoroutine(nameof(ReversRotationalOffset));
    }

    private IEnumerator ReversRotationalOffset()
    {
        effector.rotationalOffset = 180;

        yield return new WaitForSeconds(0.5f);

        effector.rotationalOffset = 0;
    }
}
