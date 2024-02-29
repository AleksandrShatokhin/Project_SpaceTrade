using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBase : MonoBehaviour, IInitialize
{
    [SerializeField] protected List<ItemSO> _items;

    [SerializeField] protected Button _panelButton;
    [SerializeField] protected GameObject _content;

    protected virtual void OnEnable()
    {
        FillSlots();
    }

    protected virtual void OnDisable()
    {
        ClearInventory();
    }

    public virtual void Initialize()
    {
        gameObject.SetActive(false);

        _panelButton.onClick.AddListener(() => { gameObject.SetActive(false); });
    }

    protected void FillSlots()
    {
        foreach (ItemSO item in _items)
        {
            foreach (Transform slot in _content.transform)
            {
                Debug.Log($"Slot: {slot.GetComponent<ISlotable>()?.GetItem()}");

                if (slot.GetComponent<ISlotable>()?.GetItem() == item || slot.GetComponent<ISlotable>()?.GetItem() == null)
                {
                    slot.GetComponent<IInitialize<ItemSO>>()?.Initialize(item);
                    break;
                }
            }
        }
    }

    protected virtual void ClearInventory()
    {
        foreach (Transform slot in _content.transform)
        {
            slot.GetComponent<ISlotable>()?.Clear();
        }
    }
}
