using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IInitialize<ItemSO>, IInitialize<Transform>
{
    private ItemSO _itemSO;

    public void Initialize(ItemSO itemSO)
    {
        _itemSO = itemSO;
    }

    public void Initialize(Transform playerTransform)
    {
        foreach (int number in CreateListNumberEnemies())
        {
            transform.GetChild(number).GetComponent<IInitialize<ItemSO>>()?.Initialize(_itemSO);
            transform.GetChild(number).GetComponent<IInitialize<Transform>>()?.Initialize(playerTransform);
        }
    }

    private List<int> CreateListNumberEnemies()
    {
        List<int> listRandomNumbers = new List<int>();

        while (listRandomNumbers.Count != 3)
        {
            int index = Random.Range(0, transform.childCount);

            if (!listRandomNumbers.Contains(index))
            {
                listRandomNumbers.Add(index);
            }
        }

        return listRandomNumbers;
    }
}
