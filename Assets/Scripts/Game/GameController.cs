using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameState _gameState;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private List<PlanetSO> _planets;

    [SerializeField] private PlanetMenu _planetMenuComponent;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private MerchantShop _merchantShop;
    [SerializeField] private GameObject _enemiesController;

    public void SetFollowerToVirtualCamera(Transform target) => _virtualCamera.Follow = target;
    public void AddItemToInventory(ItemSO item) => _playerInventory.AddItem(item);

    public GameState GameState
    {
        get { return _gameState; }
        set { _gameState = value; }
    }

    private void Start()
    {
        _planetMenuComponent.gameObject.SetActive(true);
        _planetMenuComponent.Initialize(_planets);

        _playerInventory.Initialize();
        _merchantShop.Initialize();
    }

    public void SwitchWindow(GameObject toClose, GameObject toOpen, PlanetSO planet = null)
    {
        toClose.SetActive(false);
        toOpen.SetActive(true);

        if (planet != null)
        {
            toOpen.GetComponent<IInitialize<PlanetSO>>()?.Initialize(planet);
        }
    }

    public void OpenInventory()
    {
        if (_playerInventory.gameObject.activeInHierarchy) return;
        _playerInventory.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        if (!_playerInventory.gameObject.activeInHierarchy) return;
        _playerInventory.gameObject.SetActive(false);
    }

    public void OpenMerchantShop(Merchant merchant)
    {
        if (_merchantShop.gameObject.activeInHierarchy) return;
        GameState = GameState.Trading;
        _merchantShop.OpenMerchantShop(merchant, _playerInventory);
        _merchantShop.gameObject.SetActive(true);
    }

    public void CloseMerchantShop()
    {
        if (!_merchantShop.gameObject.activeInHierarchy) return;
        GameState = GameState.GamePlay;
        _merchantShop.gameObject.SetActive(false);
    }
}
