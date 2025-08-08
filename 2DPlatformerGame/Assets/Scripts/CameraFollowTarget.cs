using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    StageData stageData;

    [SerializeField]
    Transform target;

    [SerializeField]
    bool x, y, z;

    float offsetY;

    private void Awake()
    {
        offsetY = Mathf.Abs(transform.position.y - target.position.y);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3( x ? target.position.x : transform.position.x ,
                                          y ? target.position.y : transform.position.y ,
                                          z ? target.position.z : transform.position.z);
        //이동 범위 제한
        Vector3 position = transform.position;
        position.y += offsetY;
        position.x = Mathf.Clamp(transform.position.x, stageData.CameraLimitMinX, stageData.CameraLimitMaxX);
        transform.position = position;
    }

    internal void SetUp(StageData stageData)
    {
        this.stageData = stageData;
        transform.position = new Vector3(stageData.CameraPosition.x, stageData.CameraPosition.y, -10);
    }
}
