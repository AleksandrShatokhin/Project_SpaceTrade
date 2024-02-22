using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject _sword;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sword.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IInteractable>()?.EnterInteract();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<IInteractable>()?.StayInteract(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<IInteractable>()?.ExitInteract();
    }
}
