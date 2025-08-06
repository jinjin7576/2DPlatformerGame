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
        if (ItemType == ItemType.Random)
        {
            ItemType = (ItemType)UnityEngine.Random.Range(0, itemPrefabs.Length);
        }

        GameObject item = Instantiate(itemPrefabs[(int)ItemType], transform.position, Quaternion.identity);
        item.GetComponent<ItemBase>().Setup();

        if (ItemType == ItemType.Coin)
        {
            cointCount--;
        }

        if (ItemType != ItemType.Coin || (ItemType == ItemType.Coin && cointCount == 0))
        {
            GetComponent<SpriteRenderer>().sprite = nonBrokeImage;
            isEmpty = true;
        }
    }
}
