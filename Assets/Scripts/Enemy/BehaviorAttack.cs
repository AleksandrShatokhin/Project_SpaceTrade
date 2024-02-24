using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorAttack : BehaviorBase, IInitialize<Transform>
{
    [SerializeField] private float _speed;
    private Transform _player;

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
        StopCoroutine(UpdateBehavior());
    }

    private IEnumerator UpdateBehavior()
    {
        while (transform.position != _player.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
