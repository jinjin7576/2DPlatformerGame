using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    Transform target;
    #region "region"

    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(target.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
