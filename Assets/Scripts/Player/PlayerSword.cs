using System.Collections;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private Transform _pivot;
    [SerializeField] private int _speedRotate;
    [SerializeField] private float _delayToDeactivate;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        StartCoroutine(DeactivateSword());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IHealthable>()?.TakeDamage(_damage);
    }
}
