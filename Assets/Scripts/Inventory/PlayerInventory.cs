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
        FillSlots();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameController.Instance.CloseInventory();
        }
    }

    private void FillSlots()
    {
        foreach (ItemSO item in _items)
        {
            foreach (Transform slot in _content.transform)
            {
                if (slot.GetComponent<ISlotable>()?.GetItem() == item || slot.GetComponent<ISlotable>()?.GetItem() == null)
                {
                    slot.GetComponent<IInitialize<ItemSO>>()?.Initialize(item);
                    break;
                }
            }
        }
    }

    private void ClearInventory()
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
