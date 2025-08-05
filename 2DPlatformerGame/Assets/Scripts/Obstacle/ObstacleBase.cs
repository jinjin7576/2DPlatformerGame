using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    [SerializeField]
    private bool isInstatDeath = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (isInstatDeath)
        {
            Debug.Log("�÷��̾� ���");
        }
        else
        {
            Debug.Log("�÷��̾� ü�� ����");
        }
    }
}
