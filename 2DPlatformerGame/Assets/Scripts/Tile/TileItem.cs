using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItem : TileBase
{
    [Header("Tile  Item")]
    [SerializeField]
    ItemType ItemType = ItemType.Random;
    [SerializeField]
    GameObject[] itemPrefabs;
    [SerializeField]
    int cointCount;
    [SerializeField]
    Sprite nonBrokeImage;

    bool isEmpty = false;
    public override void UpdateCollision()
    {
        if (isEmpty == true) return;
        base.UpdateCollision();

        SpawnItem();
    }

    private void SpawnItem()
    {
        
    }
}
