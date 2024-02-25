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
        StopAllCoroutines();
    }

    private IEnumerator UpdateBehavior()
    {
        while (transform.position != _targetPoint.position)
        {
            Vector3 targetPosition = new Vector3(_targetPoint.position.x, _targetPoint.position.y, transform.localPosition.z);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
