using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : ItemBase
{
    public override void UpdateCollison(Transform target)
    {
        target.GetComponent<PlayerData>().Coin++;
    }
}
