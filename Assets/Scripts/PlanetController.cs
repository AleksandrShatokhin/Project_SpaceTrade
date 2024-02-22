using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour, IInitialize<PlanetSO>
{
    private PlanetSO _planetSO;

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;

        GetComponent<SpriteRenderer>().sprite = _planetSO.SurfaceAppearance;
    }
}
