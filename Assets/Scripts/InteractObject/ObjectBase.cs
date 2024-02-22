using UnityEngine;

public abstract class ObjectBase : MonoBehaviour, IInteractable, IDeathable
{
    [SerializeField] private GameObject _indicator;

    public virtual void EnterInteract()
    {
        _indicator.SetActive(true);
    }

    public virtual void StayInteract(Transform player)
    {
        if (player.position.y <= transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + 0.1f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 0.1f);
        }
    }

    public virtual void ExitInteract()
    {
        _indicator.SetActive(false);
    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }
}
