using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour, IInitialize
{
    [SerializeField] private List<ItemSO> _items;

    [SerializeField] private Button _panelButton;
    [SerializeField] private GameObject _content;

    public void Initialize()
    {
        gameObject.SetActive(false);

        _panelButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }

    private void OnEnable()
    {
        int counter = 0;

        while (counter < _content.transform.childCount && counter < _items.Count)
        {
            _content.transform.GetChild(counter).GetComponent<IInitialize<ItemSO>>()?.Initialize(_items[counter]);
            counter++;
        }
    }

    private void OnDisable()
    {
        foreach (Transform slot in _content.transform)
        {
            slot.GetComponent<ISlotable>()?.Clear();
        }
    }

    public void AddItem(ItemSO item)
    {
        _items.Add(item);
    }
}
