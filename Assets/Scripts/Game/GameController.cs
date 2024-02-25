using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private List<PlanetSO> _planets;

    [SerializeField] private PlanetMenu _planetMenuComponent;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _enemiesController;

    public void SetFollowerToVirtualCamera(Transform target) => _virtualCamera.Follow = target;
    public void AddItemToInventory(ItemSO item) => _playerInventory.AddItem(item);

    private void Start()
    {
        _planetMenuComponent.gameObject.SetActive(true);
        _planetMenuComponent.Initialize(_planets);

        _playerInventory.Initialize();
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
}
