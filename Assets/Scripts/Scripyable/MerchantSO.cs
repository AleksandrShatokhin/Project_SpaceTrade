using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Merchant", menuName = "ScriptableObjects/Merchant", order = 4)]
public class MerchantSO : ScriptableObject
{
    public Sprite MainAppearance;

    public List<ItemSO> Assortment;
}
