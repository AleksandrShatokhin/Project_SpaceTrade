using UnityEngine;

public class InteractTree : ObjectBase, IInitialize<Sprite>
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
