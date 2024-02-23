using UnityEngine;

public class InteractStone : ObjectBase
{
    [SerializeField] private GameObject _itemPrefab;

    public override void Initialize(ItemSO item)
    {
        base.Initialize(item);
        _appearance.sprite = _item.MainAppearance;
    }

    public override void EnterInteract()
    {

    }

    public override void ExitInteract()
    {

    }

    public override void Death()
    {
        base.Death();
        CreatePickableItem(_itemPrefab);
    }
}
