using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour, IInitialize
{
    [SerializeField] private BehaviorBase _statePatroling;
    [SerializeField] private BehaviorBase _stateAttack;

    private StateHandler _stateHandler;

    public void Initialize()
    {
        _stateHandler = new StateHandler();
        _stateHandler.Initialize(_statePatroling);
        //StartCoroutine(CheckState());
    }

    //private IEnumerator CheckState()
    //{
        //while (true)
        //{
        //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3.0f);

        //    foreach (Collider2D collider in colliders)
        //    {
        //        if (collider.gameObject.tag == "Player" && _stateHandler.CurrentState == _statePatroling)
        //        {
        //            _stateHandler.ChangeState(_stateAttack);
        //        }
        //        else if (_stateHandler.CurrentState == _stateAttack)
        //        {
        //            _stateHandler.ChangeState(_statePatroling);
        //        }
        //    }

        //    yield return new WaitForSeconds(0.2f);
        //}
    //}
}
