using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractStone : ObjectBase, IInitialize<Sprite>
{
    [SerializeField] private SpriteRenderer _appearance;

    public void Initialize(Sprite appearance)
    {
        _appearance.sprite = appearance;
    }

    public override void EnterInteract()
    {

    }

    public override void ExitInteract()
    {

    }
}
