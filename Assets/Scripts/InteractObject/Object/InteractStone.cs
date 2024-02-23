using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractStone : ObjectBase, IInitialize<ItemSO>
{
    [SerializeField] private SpriteRenderer _appearance;

    private ItemSO _item;

    public void Initialize(ItemSO item)
    {
        _item = item;

        _appearance.sprite = _item.MainAppearance;
    }

    public override void EnterInteract()
    {

    }

    public override void ExitInteract()
    {

    }
}
