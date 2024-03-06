using UnityEngine;

public class PlanetController : MonoBehaviour, IInitialize<PlanetSO>
{
    [SerializeField] private SpriteRenderer _surface;
    [SerializeField] private GameObject _merchantInventory;

    [Header("Player parameters")]
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawnPosition;

    [Header("Planet objects")]
    [SerializeField] private GameObject _trees;
    [SerializeField] private GameObject _stones;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _merchant;

    private GameObject _player;
    private PlanetSO _planetSO;
    private bool _planetLoaded;

    public bool PlanetLoaded { get { return _planetLoaded; } }

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;

        _surface.sprite = _planetSO.SurfaceAppearance;

        InitializeTrees();
        InitializeStones();

        InitializePlayer();

        InitializeEnemy();

        InitializeMerchant();

        _planetLoaded = true;
    }

    private void OnDisable()
    {
        Destroy(_player);
    }

    private void InitializeTrees()
    {
        foreach (Transform tree in _trees.transform)
        {
            tree.gameObject.SetActive(false);
        }

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
            stone.gameObject.SetActive(false);
        }

        foreach (Transform stone in _stones.transform)
        {
            int randomStone = Random.Range(0, _planetSO.Stones.Count);
            stone.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Stones[randomStone]);
        }
    }

    private void InitializePlayer()
    {
        if (_player != null) _player = null;

        _player = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        GameController.Instance.SetFollowerToVirtualCamera(_player.transform);
        _player.GetComponent<IInitialize>()?.Initialize();
    }

    private void InitializeEnemy()
    {
        foreach (Transform enemy in _enemy.transform)
        {
            enemy.gameObject.SetActive(false);
        }

        _enemy.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Enemy);
        _enemy.GetComponent<IInitialize<Transform>>().Initialize(_player.transform);
    }

    private void InitializeMerchant()
    {
        foreach (Transform merchant in _merchant.transform)
        {
            merchant.gameObject.SetActive(false);
        }

        int randomMerchant = Random.Range(0, _merchant.transform.childCount);
        _merchant.transform.GetChild(randomMerchant).GetComponent<IInitialize<MerchantSO>>()?.Initialize(_planetSO.Merchant);
        _merchant.transform.GetChild(randomMerchant).GetComponent<ISetable<GameObject>>()?.SetData(_merchantInventory);
    }
}
