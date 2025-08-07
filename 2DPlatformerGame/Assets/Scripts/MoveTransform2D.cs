using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0;

    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
