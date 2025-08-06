using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInvincibility : ItemBase
{
    [SerializeField]
    private float time = 3;
    public override void UpdateCollison(Transform target)
    {
        target.GetComponent<PlayerHP>().OnInvincibility(time);
    }
}
