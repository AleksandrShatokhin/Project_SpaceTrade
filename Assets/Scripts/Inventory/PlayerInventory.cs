using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour, IInitialize
{
    [SerializeField] private Dictionary<ItemSO, int> _inventory;
    [SerializeField] private int _money;

    [SerializeField] private Button _panelButton;
    [SerializeField] private GameObject _content;

    public Dictionary<ItemSO, int> Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }

    private void OnEnable()
    {
        FillSlots();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    public virtual void Initialize()
    {
        _inventory = new Dictionary<ItemSO, int>();
        gameObject.SetActive(false);
        _panelButton.onClick.AddListener(() => { gameObject.SetActive(false); });
        _money = 30;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameController.Instance.CloseInventory();
        }
    }

    public void AddItem(ItemSO item)
    {
        if (!_inventory.ContainsKey(item))
        {
            _inventory.Add(item, 1);
        }
        else
        {
            int tempCount = _inventory.GetValueOrDefault(item);
            tempCount += 1;
            _inventory.Remove(item);
            _inventory.Add(item, tempCount);
        }
    }

    private void FillSlots()
    {
        List<ItemSO> items = _inventory.Keys.ToList();
        List<int> counts = _inventory.Values.ToList();

        int counter = 0;

        while (counter < _inventory.Count)
        {
            _content.transform.GetChild(counter).GetComponent<InventorySlot>().SetItem(items[counter], counts[counter]);
            counter += 1;
        }
    }

    private void ClearInventory()
    {
        foreach (Transform slot in _content.transform)
        {
            slot.GetComponent<InventorySlot>()?.Clear();
        }
    }
}