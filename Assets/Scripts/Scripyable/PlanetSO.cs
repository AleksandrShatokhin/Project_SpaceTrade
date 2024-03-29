using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "ScriptableObjects/Planet", order = 1)]
public class PlanetSO : ScriptableObject
{
    public Sprite SpaceAppearance;
    public Sprite SurfaceAppearance;

    [TextArea] public string Description;

    public List<ItemSO> Trees;
    public List<ItemSO> Stones;
    public ItemSO Enemy;
    public MerchantSO Merchant;
}
