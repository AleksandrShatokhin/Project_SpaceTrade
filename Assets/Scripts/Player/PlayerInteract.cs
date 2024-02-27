using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject _sword;

    [SerializeField] private ObjectBase _object;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GameController.Instance.OpenInventory();
        }
    }

    private void Attack()
    {
        if (_sword.activeInHierarchy) return;
        _sword.SetActive(true);
    }

    private void InteractWithObject()
    {
        if (_object == null) return;
        _object.GetComponent<IInteractable>()?.ActionInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectBase obj = collision.GetComponent<ObjectBase>();
        if (obj == null) return;
        obj.GetComponent<IInteractable>()?.EnterInteract();
        _object = obj;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<IInteractable>()?.StayInteract(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ObjectBase obj = collision.GetComponent<ObjectBase>();
        if (obj == null) return;
        obj.GetComponent<IInteractable>()?.ExitInteract();
        if (obj == _object) _object = null;
    }
}
