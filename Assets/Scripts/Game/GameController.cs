using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        GameObject player = Instantiate(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity);
        player.GetComponent<IInitialize>()?.Initialize();
    }
}
