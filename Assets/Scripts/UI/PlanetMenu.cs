using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetMenu : MonoBehaviour, IInitialize<List<PlanetSO>>
{
    [Header("External links")]
    [SerializeField] private GameObject _planet;

    [Header("Internal links")]
    [SerializeField] private List<GameObject> _planets;
    [SerializeField] private GameObject _description;

    public void Initialize(List<PlanetSO> planetsSO)
    {
        int counter = 0;

        while (counter < _planets.Count && counter < planetsSO.Count)
        {
            _planets[counter].GetComponent<IInitialize<PlanetSO>>()?.Initialize(planetsSO[counter]);
            counter++;
        }
    }

    public void GoToPlanet(PlanetSO planetSO)
    {
        GameController.Instance.SwitchWindow(this.gameObject, _planet, planetSO);
    }

    public void OpenDescription(PlanetSO planetSO)
    {
        _description.SetActive(true);
        _description.GetComponentInChildren<TextMeshProUGUI>().text = planetSO.Description;
    }

    public void CloseDescription()
    {
        _description.SetActive(false);
        _description.GetComponentInChildren<TextMeshProUGUI>().text = null;
    }
}
