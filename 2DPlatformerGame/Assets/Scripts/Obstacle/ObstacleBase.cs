using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private bool isInstatDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (isInstatDeath)
        {
            Debug.Log("플레이어 사망");
        }
        else
        {
            //Debug.Log("플레이어 체력 감소");
            collision.GetComponent<PlayerHP>().DecreaseHP();
        }
    }
}
