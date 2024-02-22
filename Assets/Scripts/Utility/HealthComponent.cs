using UnityEngine;

public class HealthComponent : MonoBehaviour, IHealthable
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        _health = _health - damage;

        if (_health <= 0)
        {
            GetComponentInParent<IDeathable>()?.Death();
        }
    }
}
