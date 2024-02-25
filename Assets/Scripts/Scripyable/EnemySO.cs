using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/Enemy", order = 3)]
public class EnemySO : ScriptableObject
{
    public string Name;

    public Sprite MainAppearance;
    public Sprite ItemApperance;
    public Sprite InventoryAppearance;
}
