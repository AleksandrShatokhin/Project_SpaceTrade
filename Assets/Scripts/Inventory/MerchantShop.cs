using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerchantShop : MonoBehaviour, IInitialize, ITradable
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _sellButton;

    [SerializeField] private GameObject _buyIndicator;
    [SerializeField] private GameObject _sellIndicator;

    [SerializeField] private TextMeshProUGUI _merchantMoney;
    [SerializeField] private TextMeshProUGUI _playerMoney;

    [SerializeField] private GameObject _merchantInventoryGO;
    [SerializeField] private GameObject _playerInventoryGO;

    [SerializeField] protected Button _panelButton;
    [SerializeField] protected GameObject _contentMerchant;
    [SerializeField] protected GameObject _contentPlayer;

    private Merchant _merchant;
    private PlayerInventory _playerInventory;

    private void OnEnable()
    {
        FillSlots();
    }

    private void OnDisable()
    {
        ClearInventory();
    }

    public void Initialize()
    {
        gameObject.SetActive(false);
        _panelButton.onClick.AddListener(() => { GameController.Instance.CloseMerchantShop(); });
        _buyButton.onClick.AddListener(ClickButtonBuy);
        _sellButton.onClick.AddListener(ClickButtonSell);
    }

    private void ClickButtonBuy()
    {
        _merchantInventoryGO.SetActive(true);
        _playerInventoryGO.SetActive(false);
        _buyIndicator.SetActive(true);
        _sellIndicator.SetActive(false);
        _merchantMoney.transform.parent.gameObject.SetActive(true);
        _playerMoney.transform.parent.gameObject.SetActive(false);
    }

    private void ClickButtonSell()
    {
        _merchantInventoryGO.SetActive(false);
        _playerInventoryGO.SetActive(true);
        _buyIndicator.SetActive(false);
        _sellIndicator.SetActive(true);
        _merchantMoney.transform.parent.gameObject.SetActive(false);
        _playerMoney.transform.parent.gameObject.SetActive(true);
    }

    public void OpenMerchantShop(Merchant merchant, PlayerInventory playerInventory)
    {
        _merchant = merchant;
        _playerInventory = playerInventory;

        _merchantMoney.text = _merchant.Money.ToString();
        _playerMoney.text = _playerInventory.Money.ToString();

        ClickButtonBuy();
    }

    private void FillSlots()
    {
        FillAssortment(_contentMerchant, _merchant.Assortment);
        FillAssortment(_contentPlayer, _playerInventory.Inventory);
    }

    private void FillAssortment(GameObject content, Dictionary<ItemSO, int> assortment)
    {
        List<ItemSO> items = assortment.Keys.ToList();
        List<int> counts = assortment.Values.ToList();

        int counter = 0;

        while (counter < assortment.Count)
        {
            content.transform.GetChild(counter).GetComponent<InventorySlot>().SetItem(items[counter], counts[counter]);
            counter += 1;
        }
    }

    private void ClearInventory()
    {
        foreach (Transform slot in _contentMerchant.transform)
        {
            slot.GetComponent<InventorySlot>()?.Clear();
        }

        foreach (Transform slot in _contentPlayer.transform)
        {
            slot.GetComponent<InventorySlot>()?.Clear();
        }
    }

    public void MakeDeal(GameObject content, KeyValuePair<ItemSO, int> item)
    {
        if (content == _contentMerchant)
        {
            _merchant.Assortment.Remove(item.Key);
            _playerInventory.Inventory.Add(item.Key, item.Value);
        }

        if (content == _contentPlayer)
        {
            _playerInventory.Inventory.Remove(item.Key);
            _merchant.Assortment.Add(item.Key, item.Value);
        }

        Debug.Log($"Merchant assortment: {_merchant.Assortment.Count}");
        Debug.Log($"Player assortment: {_playerInventory.Inventory.Count}");

        UpdateAssortment();
    }

    private void UpdateAssortment()
    {
        ClearInventory();
        FillSlots();
    }
}
