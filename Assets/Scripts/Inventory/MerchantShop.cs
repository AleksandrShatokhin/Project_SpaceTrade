using System;
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
        FillAssortment(_contentMerchant, _merchant.Assortment, _merchant.PriceCoefficient);
        FillAssortment(_contentPlayer, _playerInventory.Inventory);
    }

    private void FillAssortment(GameObject content, Dictionary<ItemSO, int> assortment, float merchantCoefficient = 1)
    {
        List<ItemSO> items = assortment.Keys.ToList();
        List<int> counts = assortment.Values.ToList();

        int counter = 0;

        while (counter < assortment.Count)
        {
            ItemSO item = items[counter];
            int count = counts[counter];
            float planetCoefficient = _merchant.GetPlanetCoefficient(items[counter].ItemType);

            content.transform.GetChild(counter).GetComponent<InventorySlot>().SetItem(item, count, planetCoefficient, merchantCoefficient);
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

    public void MakeDeal(GameObject content, ItemSO item, int count, int price)
    {
        if (content == _contentMerchant)
        {
            if (_playerInventory.Money > price)
            {
                int tempCount = _merchant.Assortment.GetValueOrDefault(item);

                if (tempCount == 1)
                {
                    _merchant.Assortment.Remove(item);
                    _playerInventory.AddItem(item);
                }
                else
                {
                    tempCount -= 1;
                    _merchant.Assortment.Remove(item);
                    _merchant.Assortment.Add(item, tempCount);
                    _playerInventory.AddItem(item);
                }

                _playerInventory.Money -= price;
                _playerMoney.text = _playerInventory.Money.ToString();

                _merchant.Money += price;
                _merchantMoney.text = _merchant.Money.ToString();
            }
            else
            {
                Debug.Log("The PLAYER doesn't have enough money!");
            }
        }

        if (content == _contentPlayer)
        {
            if (_merchant.Money > price)
            {
                int tempCount = _playerInventory.Inventory.GetValueOrDefault(item);

                if (tempCount == 1)
                {
                    _playerInventory.Inventory.Remove(item);
                    _merchant.AddItem(item);
                }
                else
                {
                    tempCount -= 1;
                    _playerInventory.Inventory.Remove(item);
                    _playerInventory.Inventory.Add(item, tempCount);
                    _merchant.AddItem(item);
                }

                _merchant.Money -= price;
                _merchantMoney.text = _merchant.Money.ToString();

                _playerInventory.Money += price;
                _playerMoney.text = _playerInventory.Money.ToString();
            }
            else
            {
                Debug.Log("The MERCHANT doesn't have enough money!");
            }
        }

        UpdateAssortment();
    }

    //public void MakeDeal(GameObject content, KeyValuePair<ItemSO, int> item)
    //{
    //    if (content == _contentMerchant)
    //    {
    //        if (_playerInventory.Money > PriceRarser.GetParsePrice(item.Key.Price, _merchant.PriceCoefficient))
    //        {
    //            int tempCount = _merchant.Assortment.GetValueOrDefault(item.Key);

    //            if (tempCount == 1)
    //            {
    //                _merchant.Assortment.Remove(item.Key);
    //                _playerInventory.AddItem(item.Key);
    //            }
    //            else
    //            {
    //                tempCount -= 1;
    //                _merchant.Assortment.Remove(item.Key);
    //                _merchant.Assortment.Add(item.Key, tempCount);
    //                _playerInventory.AddItem(item.Key);
    //            }

    //            _playerInventory.Money -= (int)PriceRarser.GetParsePrice(item.Key.Price, _merchant.PriceCoefficient);
    //            _playerMoney.text = _playerInventory.Money.ToString();

    //            _merchant.Money += (int)PriceRarser.GetParsePrice(item.Key.Price, _merchant.PriceCoefficient);
    //            _merchantMoney.text = _merchant.Money.ToString();
    //        }
    //        else
    //        {
    //            Debug.Log("The PLAYER doesn't have enough money!");
    //        }
    //    }

    //    if (content == _contentPlayer)
    //    {
    //        if (_merchant.Money > item.Key.Price)
    //        {
    //            int tempCount = _playerInventory.Inventory.GetValueOrDefault(item.Key);

    //            if (tempCount == 1)
    //            {
    //                _playerInventory.Inventory.Remove(item.Key);
    //                _merchant.AddItem(item.Key);
    //            }
    //            else
    //            {
    //                tempCount -= 1;
    //                _playerInventory.Inventory.Remove(item.Key);
    //                _playerInventory.Inventory.Add(item.Key, tempCount);
    //                _merchant.AddItem(item.Key);
    //            }

    //            _merchant.Money -= item.Key.Price;
    //            _merchantMoney.text = _merchant.Money.ToString();

    //            _playerInventory.Money += item.Key.Price;
    //            _playerMoney.text = _playerInventory.Money.ToString();
    //        }
    //        else
    //        {
    //            Debug.Log("The MERCHANT doesn't have enough money!");
    //        }
    //    }

    //    UpdateAssortment();
    //}

    private void UpdateAssortment()
    {
        ClearInventory();
        FillSlots();
    }
}
