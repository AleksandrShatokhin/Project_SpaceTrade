using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    [SerializeField] private Transform _nextPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<BehaviorPatroling>()?.SetTargetPoint(_nextPoint);
    }
}
