using System.Collections;
using UnityEngine;

public class BehaviorAttack : BehaviorBase, IInitialize<Transform>
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;

    public void Initialize(Transform player)
    {
        _player = player;
    }

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
        while (transform.position != _player.position)
        {
            Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y, transform.localPosition.z);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
