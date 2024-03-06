using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private TextMeshProUGUI _price;

    private ItemSO _item;
    private int _counter = 0;
    private int _itemPrice;

    public void SetItem(ItemSO item, int count, float planetPriceCoefficient = 1, float merchantPriceCoefficient = 1)
    {
        _item = item;
        _counter = count;

        gameObject.SetActive(true);

        _name.text = _item.Name;
        _image.sprite = _item.InventoryAppearance;
        _count.text = _counter.ToString();

        _itemPrice = (int)PriceRarser.GetParsePrice(_item.Price, planetPriceCoefficient, merchantPriceCoefficient);
        _price.text = _itemPrice.ToString();
    }

    public void Clear()
    {
        _item = null;

        _name.text = "";
        _image.sprite = null;
        _counter = 0;

        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameController.Instance.GameState == GameState.GamePlay) return;
        GetComponentInParent<ITradable>()?.MakeDeal(transform.parent.gameObject, _item, _counter, _itemPrice);
    }
}
