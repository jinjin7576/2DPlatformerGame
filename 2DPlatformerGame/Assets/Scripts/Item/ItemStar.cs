using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStar : ItemBase
{
    [Tooltip("별은 한 스테이지에 항상 3개, 순번 0,1,2 부여")]
    [SerializeField]
    [Range(0, 2)]
    private int starIndex;
    public override void UpdateCollison(Transform target)
    {
        target.GetComponent<PlayerData>().GetStar(starIndex);
    }
}
