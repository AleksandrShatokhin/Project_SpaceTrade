using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour, IInitialize<PlanetSO>, IPointerDownHandler
{
    [SerializeField] private Image _planetImage;

    private PlanetSO _planetSO;

    public void Initialize(PlanetSO planetSO)
    {
        _planetSO = planetSO;
        _planetImage.sprite = _planetSO.SpaceAppearance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"Click on {gameObject.name}");
        GetComponentInParent<PlanetMenu>().OpenPlanet(_planetSO);
    }
}
