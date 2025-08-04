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
        base.UpdateCollision(); //부모 클래스의 함수 호출
        Instantiate(tileBrokeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
