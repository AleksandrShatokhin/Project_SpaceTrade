using System.Collections;
using UnityEngine;

public class BehaviorAttack : BehaviorBase, IInitialize<Transform>
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private float _speed;

    private Transform _player;
    private bool isCanAttack;

    public void Initialize(Transform player)
    {
        _player = player;
        isCanAttack = true;
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
            if (Vector2.Distance(transform.position, _player.position) > 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            }
            else
            {
                Attack();
            }

            SetDirection(_player);

            yield return null;
        }
    }

    private void Attack()
    {
        if (_weapon.activeInHierarchy || !isCanAttack) return;
        StartCoroutine(ReloadAttacking());
        _weapon.SetActive(true);
    }

    private IEnumerator ReloadAttacking()
    {
        isCanAttack = false;
        yield return new WaitForSeconds(2.0f);
        isCanAttack = true;
    }
}
