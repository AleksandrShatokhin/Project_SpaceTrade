public class Item : ObjectBase
{
    public override void Initialize(ItemSO item)
    {
        base.Initialize(item);
        _appearance.sprite = _item.ItemApperance;
    }

    public override void ActionInteract()
    {
        GameController.Instance.AddItemToInventory(_item);
        Destroy(gameObject);
    }
}
