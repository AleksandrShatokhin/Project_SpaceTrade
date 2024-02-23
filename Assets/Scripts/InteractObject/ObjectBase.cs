using UnityEngine;

public abstract class ObjectBase : MonoBehaviour, IInteractable, IDeathable, IInitialize<ItemSO>
{
    [SerializeField] protected GameObject _indicator;
    [SerializeField] protected SpriteRenderer _appearance;

    protected ItemSO _item;

    public virtual void Initialize(ItemSO item)
    {
        _item = item;
    }

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

    public virtual void ActionInteract()
    {

    }

    public virtual void Death()
    {
        gameObject.SetActive(false);
    }

    protected virtual void CreatePickableItem(GameObject prefab)
    {
        GameObject item = Instantiate(prefab, transform.position, Quaternion.identity);
        item.GetComponent<IInitialize<ItemSO>>()?.Initialize(_item);
    }
}
