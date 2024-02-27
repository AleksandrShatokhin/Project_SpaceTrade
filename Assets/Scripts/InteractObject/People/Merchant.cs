using System.Collections.Generic;
using UnityEngine;

public class Merchant : ObjectBase, IInitialize<MerchantSO>, ISetable<GameObject>
{
    private GameObject _inventory;
    private MerchantSO _merchantSO;

    public void Initialize(MerchantSO merchantSO)
    {
        gameObject.SetActive(true);

        _merchantSO = merchantSO;
        _appearance.sprite = _merchantSO.MainAppearance;
    }

    public void SetData(GameObject inventory)
    {
        _inventory = inventory;
        _inventory.GetComponent<ISetable<List<ItemSO>>>()?.SetData(_merchantSO.Assortment);
        _inventory.GetComponent<IInitialize>()?.Initialize();
    }

    public override void ActionInteract()
    {
        if (_inventory.activeInHierarchy) return;
        _inventory.SetActive(true);
    }
}
