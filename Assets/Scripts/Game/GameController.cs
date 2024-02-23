using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private List<PlanetSO> _planets;

    [SerializeField] private PlanetMenu _planetMenuComponent;
    [SerializeField] private PlayerInventory _playerInventory;

    private void Start()
    {
        _planetMenuComponent.gameObject.SetActive(true);
        _planetMenuComponent.Initialize(_planets);

        _playerInventory.Initialize();
    }

    private void InitializePlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        _virtualCamera.Follow = player.transform;
        player.GetComponent<IInitialize>()?.Initialize();
    }

    public void SwitchWindow(GameObject toClose, GameObject toOpen, PlanetSO planet = null)
    {
        toClose.SetActive(false);
        toOpen.SetActive(true);

        if (planet != null)
        {
            toOpen.GetComponent<IInitialize<PlanetSO>>()?.Initialize(planet);
            InitializePlayer();
        }
    }

    public void AddItemToInventory(ItemSO item)
    {
        _playerInventory.AddItem(item);
    }

    public void OpenInventory(bool value)
    {
        _playerInventory.gameObject.SetActive(value);
    }
}
