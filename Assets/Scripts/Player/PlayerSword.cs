using System.Collections;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private int _speedRotate;
    [SerializeField] private float _delayToDeactivate;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;

    private void OnEnable()
    {
        StartCoroutine(DeactivateSword());

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_pivot.position, _radius);

        foreach (Collider2D collider in colliders)
        {
            Debug.Log(collider.gameObject.name);
            collider.GetComponent<IHealthable>()?.TakeDamage(_damage);
        }
    }

    private void Update()
    {
        transform.RotateAround(_pivot.position, Vector3.forward, GetParsSpeed(_speedRotate) * Time.deltaTime);
    }

    private int GetParsSpeed(int speed)
    {
        speed = speed * 10;
        return speed;
    }

    private IEnumerator DeactivateSword()
    {
        yield return new WaitForSeconds(_delayToDeactivate);
        gameObject.SetActive(false);
    }
}
