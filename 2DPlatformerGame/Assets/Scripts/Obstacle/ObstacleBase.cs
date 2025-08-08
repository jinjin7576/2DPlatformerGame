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
            collision.GetComponent<PlayerController>().OnDie();
        }
        else
        {
            //Debug.Log("�÷��̾� ü�� ����");
            collision.GetComponent<PlayerHP>().DecreaseHP();
        }
    }
}
