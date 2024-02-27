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
            if (collider.gameObject == this.transform.parent.gameObject) continue;
            collider.GetComponent<IHealthable>()?.TakeDamage(_damage);
        }
    }

    private void Update()
    {
        transform.RotateAround(_pivot.position, Vector3.forward, GetParseSpeed(_speedRotate) * Time.deltaTime);
        CheckAngle();
    }

    private int GetParseSpeed(int speed)
    {
        speed = speed * 10;
        return speed;
    }

    private IEnumerator DeactivateSword()
    {
        yield return new WaitForSeconds(_delayToDeactivate);
        gameObject.SetActive(false);
    }

    private void CheckAngle()
    {
        if (transform.localEulerAngles.z >= 0 && transform.localEulerAngles.z < 180)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _pivot.position.z + 0.01f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _pivot.position.z - 0.01f);
        }
    }
}
