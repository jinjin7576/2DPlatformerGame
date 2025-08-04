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

    //�ܺο��� ���� �����Ϳ� �����ϱ� ���� ������Ƽ get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimITMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;

}
