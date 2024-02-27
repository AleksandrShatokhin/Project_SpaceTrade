using System.Collections.Generic;

public class MerchantShop : InventoryBase, ISetable<List<ItemSO>>
{
    public void SetData(List<ItemSO> assortment) => _items = assortment;
}
