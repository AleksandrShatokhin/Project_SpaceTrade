using System.Collections.Generic;
using UnityEngine;

public class Merchant : ObjectBase, IInitialize<MerchantSO>, ISetable<GameObject>
{
    [SerializeField] private int _money;

    private GameObject _inventory;
    private MerchantSO _merchantSO;

    private Dictionary<ItemSO, int> _assortment;

    public Dictionary<ItemSO, int> Assortment
    {
        get { return _assortment; }
        set { _assortment = value; }
    }

    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }

    public void Initialize(MerchantSO merchantSO)
    {
        gameObject.SetActive(true);

        _merchantSO = merchantSO;
        _appearance.sprite = _merchantSO.MainAppearance;
        _money = _merchantSO.Money;

        FillAssortment();
    }

    private void FillAssortment()
    {
        _assortment = new Dictionary<ItemSO, int>();

        int counter = 0;

        while (counter < _merchantSO.Assortment.Count)
        {
            _assortment.Add(_merchantSO.Assortment[counter], _merchantSO.ItemCounts[counter]);
            counter += 1;
        }
    }

    public void AddItem(ItemSO item)
    {
        if (!_assortment.ContainsKey(item))
        {
            _assortment.Add(item, 1);
        }
        else
        {
            int tempCount = _assortment.GetValueOrDefault(item);
            tempCount += 1;
            _assortment.Remove(item);
            _assortment.Add(item, tempCount);
        }
    }

    public void SetData(GameObject inventory)
    {
        _inventory = inventory;
        _inventory.GetComponent<ISetable<List<ItemSO>>>()?.SetData(_merchantSO.Assortment);
        _inventory.GetComponent<IInitialize>()?.Initialize();
    }

    public override void ActionInteract()
    {
        GameController.Instance.OpenMerchantShop(this);
    }
}
