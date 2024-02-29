using System.Collections.Generic;
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

    public void SetItem(ItemSO item, int count)
    {
        _item = item;
        _counter = count;

        gameObject.SetActive(true);

        _name.text = _item.Name;
        _image.sprite = _item.InventoryAppearance;
        _count.text = _counter.ToString();

        _price.text = _item.Price.ToString();
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

        KeyValuePair<ItemSO, int> tempItem = new KeyValuePair<ItemSO, int>(_item, _counter);
        GetComponentInParent<ITradable>()?.MakeDeal(transform.parent.gameObject, tempItem);
    }
}
