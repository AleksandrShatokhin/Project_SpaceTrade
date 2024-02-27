using System.Collections;
using UnityEngine;

public class EnemyBehaviorHandler : ObjectBase
{
    [SerializeField] private BehaviorBase _statePatroling;
    [SerializeField] private BehaviorBase _stateAttack;
    [SerializeField] private float _radiusFieldOfView;
    [SerializeField] private GameObject _itemPrefab;

    private StateHandler _stateHandler;

    public override void Initialize(ItemSO itemSO)
    {
        gameObject.SetActive(true);
        _item = itemSO;
        _appearance.sprite = _item.MainAppearance;

        _stateHandler = new StateHandler();
        _stateHandler.Initialize(_statePatroling);

        StartCoroutine(CheckState());
    }

    private IEnumerator CheckState()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            bool isPlayer = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radiusFieldOfView);

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Player")
                {
                    isPlayer = true;
                }

                BehaviorBase temp = (isPlayer) ? _stateAttack : _statePatroling;
                _stateHandler.ChangeState(temp);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public override void EnterInteract()
    {

    }

    public override void StayInteract(Transform player)
    {
        base.StayInteract(player);
    }

    public override void ExitInteract()
    {

    }

    public override void Death()
    {
        base.Death();
        CreatePickableItem(_itemPrefab);
    }
}