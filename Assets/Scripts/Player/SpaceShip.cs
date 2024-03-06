using UnityEngine;

public class SpaceShip : ObjectBase
{
    [SerializeField] private GameObject _space;
    [SerializeField] private GameObject _planet;

    public override void ActionInteract()
    {
        GameController.Instance.SwitchWindow(_planet, _space);
    }
}
