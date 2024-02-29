using System.Collections.Generic;
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
    void ActionInteract();
}

public interface IHealthable
{
    void TakeDamage(int damage);
}

public interface IDeathable
{
    void Death();
}

public interface ISlotable
{
    ItemSO GetItem();
    void Clear();
}

public interface ISetable<T>
{
    void SetData(T data);
}

public interface ITradable
{
    void MakeDeal(GameObject content, ItemSO item, int count, int price);
}

//public interface ITradable
//{
//    void MakeDeal(GameObject content, KeyValuePair<ItemSO, int> item);
//}