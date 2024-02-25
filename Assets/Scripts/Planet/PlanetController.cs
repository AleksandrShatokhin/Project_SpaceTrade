using UnityEngine;

public class PlanetController : MonoBehaviour, IInitialize<PlanetSO>
{
    [SerializeField] private SpriteRenderer _surface;

    [Header("Player parameters")]
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawnPosition;

    [Header("Planet objects")]
    [SerializeField] private GameObject _trees;
    [SerializeField] private GameObject _stones;
    [SerializeField] private GameObject _enemy;

    private GameObject _player;
    private PlanetSO _planetSO;

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;

        _surface.sprite = _planetSO.SurfaceAppearance;

        InitializeTrees();
        InitializeStones();

        InitializePlayer();

        InitializeEnemy();
    }

    private void InitializeTrees()
    {
        foreach (Transform tree in _trees.transform)
        {
            int randomTree = Random.Range(0, _planetSO.Trees.Count);
            tree.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Trees[randomTree]);
        }
    }

    private void InitializeStones()
    {
        foreach (Transform stone in _stones.transform)
        {
            int randomStone = Random.Range(0, _planetSO.Stones.Count);
            stone.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Stones[randomStone]);
        }
    }

    private void InitializePlayer()
    {
        _player = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        GameController.Instance.SetFollowerToVirtualCamera(_player.transform);
        _player.GetComponent<IInitialize>()?.Initialize();
    }

    private void InitializeEnemy()
    {
        _enemy.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Enemy);
        _enemy.GetComponent<IInitialize<Transform>>().Initialize(_player.transform);
    }
}
