using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMushroomAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    
    public void OnDieEvent()
    {
        Destroy(parent);
    }
}
