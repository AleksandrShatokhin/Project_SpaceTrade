using System.Collections;
using UnityEngine;

public class BehaviorPatroling : BehaviorBase
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _speed;

    public void SetTargetPoint(Transform target) => _targetPoint = target;

    public override void Enter()
    {
        StartCoroutine(UpdateBehavior());
    }

    public override void Exit()
    {
        StopCoroutine(UpdateBehavior());
    }

    private IEnumerator UpdateBehavior()
    {
        while (transform.position != _targetPoint.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
