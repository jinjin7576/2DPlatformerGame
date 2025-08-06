using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotionItem : ItemBase
{
    public override void UpdateCollison(Transform target)
    {
        target.GetComponent<PlayerHP>().IncreaseHP();
    }
}
