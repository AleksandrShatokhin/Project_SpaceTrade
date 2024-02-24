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
    [SerializeField] private GameObject _enemies;

    private GameObject _player;

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
            InitializePlayer();
            InitializeEnemies();
        }
    }

    private void InitializePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        _virtualCamera.Follow = _player.transform;
        _player.GetComponent<IInitialize>()?.Initialize();
    }

    private void InitializeEnemies()
    {
        foreach (Transform enemy in _enemies.transform)
        {
            enemy.GetComponent<IInitialize>()?.Initialize();
            enemy.GetComponent<IInitialize<Transform>>()?.Initialize(_player.transform);
        }
    }

    public void AddItemToInventory(ItemSO item)
    {
        _playerInventory.AddItem(item);
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
