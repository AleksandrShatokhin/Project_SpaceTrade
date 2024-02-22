using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour, IInitialize<PlanetSO>, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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
        GetComponentInParent<PlanetMenu>().OpenPlanet(_planetSO);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<PlanetMenu>().OpenDescription(_planetSO);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<PlanetMenu>().CloseDescription();
    }
}
