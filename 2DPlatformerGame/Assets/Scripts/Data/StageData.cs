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

    [Header("Start Position")]
    [SerializeField]
    private Vector2 playerPosition;
    [SerializeField]
    private Vector2 cameraPosition;

    //�ܺο��� ���� �����Ϳ� �����ϱ� ���� ������Ƽ get
    public float CameraLimitMinX => cameraLimitMinX;
    public float CameraLimitMaxX => cameraLimitMaxX;
    public float PlayerLimitMinX => playerLimitMinX;
    public float PlayerLimITMaxX => playerLimitMaxX;
    public float MapLimitMinY => mapLimitMinY;
    public Vector2 PlayerPosition => playerPosition;
    public Vector2 CameraPosition => cameraPosition;

}
