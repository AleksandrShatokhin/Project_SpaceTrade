using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour, IInitialize<PlanetSO>
{
    [SerializeField] private SpriteRenderer _surface;
    [SerializeField] private GameObject _trees;
    [SerializeField] private GameObject _stones;

    private PlanetSO _planetSO;

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;

        _surface.sprite = _planetSO.SurfaceAppearance;

        foreach (Transform tree in _trees.transform)
        {
            int randomTree = Random.Range(0, _planetSO.Trees.Count);
            tree.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Trees[randomTree]);
        }

        foreach (Transform stone in _stones.transform)
        {
            int randomStone = Random.Range(0, _planetSO.Stones.Count);
            stone.GetComponent<IInitialize<ItemSO>>()?.Initialize(_planetSO.Stones[randomStone]);
        }
    }
}
