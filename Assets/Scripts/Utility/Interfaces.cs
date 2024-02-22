using UnityEngine;

public interface IInitialize
{
    void Initialize();
}

public interface IInitialize<T>
{
    void Initialize(T type);
}

public interface IInteractable
{
    void EnterInteract();
    void StayInteract(Transform transform);
    void ExitInteract();
}

public interface IHealthable
{
    void TakeDamage(int damage);
}

public interface IDeathable
{
    void Death();
}