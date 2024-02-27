using UnityEngine;

public class PlayerInventory : InventoryBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameController.Instance.CloseInventory();
        }
    }

    public void AddItem(ItemSO item)
    {
        _items.Add(item);
    }
}
