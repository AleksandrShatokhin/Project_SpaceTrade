using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour, IInitialize<PlanetSO>
{
    [SerializeField] private SpriteRenderer _surface;

    private PlanetSO _planetSO;

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;

        _surface.sprite = _planetSO.SurfaceAppearance;
    }
}
