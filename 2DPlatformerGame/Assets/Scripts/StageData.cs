using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    [Header("Camera Limit")]
    [SerializeField]
    float cameraLimitMinX;
    [SerializeField]
    float cameraLimitMaxX;

    [Header("Player Limit")]
    [SerializeField]
    float playerLimitMinX;
    [SerializeField]
    float playerLimitMaxX;

    [Header("Map Limit")]
    [SerializeField]
    float mapLimitMinY;

    //외부에서 변수 데이터에 접근하기 위한 프로퍼티 get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimITMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;

}
