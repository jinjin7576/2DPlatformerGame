using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBroke : TileBase
{
    [Header("Tile Broke")]
    [SerializeField]
    GameObject tileBrokeEffect;
    
    public override void UpdateCollision()
    {
        base.UpdateCollision(); //�θ� Ŭ������ �Լ� ȣ��
        Instantiate(tileBrokeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
