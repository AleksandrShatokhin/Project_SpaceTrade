using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IInitialize<ItemSO>, ISlotable
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _count;

    private ItemSO _item;
    private int _counter = 0;

    public ItemSO GetItem() => _item;

    public void Initialize(ItemSO item)
    {
        _item = item;

        _count.text = _counter.ToString();

        gameObject.SetActive(true);

        _name.text = _item.Name;
        _image.sprite = _item.InventoryAppearance;

        _counter++;
        _count.text = _counter.ToString();
    }

    public void Clear()
    {
        _item = null;

        _name.text = "";
        _image.sprite = null;
        _counter = 0;

        gameObject.SetActive(false);
    }
}
