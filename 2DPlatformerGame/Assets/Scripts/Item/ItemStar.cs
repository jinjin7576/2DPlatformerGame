using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStar : ItemBase
{
    [Tooltip("���� �� ���������� �׻� 3��, ���� 0,1,2 �ο�")]
    [SerializeField]
    [Range(0, 2)]
    private int starIndex;
    public override void UpdateCollison(Transform target)
    {
        target.GetComponent<PlayerData>().GetStar(starIndex);
    }
}
