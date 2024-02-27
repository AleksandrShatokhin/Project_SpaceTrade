using UnityEngine;

public abstract class BehaviorBase : MonoBehaviour
{
    private bool _isFacingRight;

    public abstract void Enter();
    public abstract void Exit();

    protected void SetDirection(Transform target)
    {
        if (_isFacingRight == false && target.position.x < transform.position.x)
        {
            SwitchDirection();
        }

        if (_isFacingRight == true && target.position.x > transform.position.x)
        {
            SwitchDirection();
        }
    }

    protected void SwitchDirection()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x = scaler.x * -1;
        transform.localScale = scaler;
    }
}