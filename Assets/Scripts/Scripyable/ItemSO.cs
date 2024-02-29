using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 2)]
public class ItemSO : ScriptableObject
{
    public string Name;
    public ItemType ItemType;

    public Sprite MainAppearance;
    public Sprite ItemApperance;
    public Sprite InventoryAppearance;

    public int Price;
}