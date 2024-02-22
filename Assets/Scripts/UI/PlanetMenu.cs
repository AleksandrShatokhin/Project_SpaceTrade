using System.Collections.Generic;
using UnityEngine;

public class PlanetMenu : MonoBehaviour, IInitialize<List<PlanetSO>>
{
    [SerializeField] private GameObject _planet;

    public void Initialize(List<PlanetSO> planets)
    {
        int counter = 0;

        while (counter < transform.childCount || counter < planets.Count)
        {
            transform.GetChild(counter).GetComponent<IInitialize<PlanetSO>>()?.Initialize(planets[counter]);
            counter++;
        }
    }

    public void OpenPlanet(PlanetSO planetSO)
    {
        GameController.Instance.SwitchWindow(this.gameObject, _planet, planetSO);
    }
}
