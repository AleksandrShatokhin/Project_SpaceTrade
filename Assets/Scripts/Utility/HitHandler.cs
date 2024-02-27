using System.Collections;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRender;

    public void TakeHit()
    {
        StartCoroutine(RedEffect());
    }

    private IEnumerator RedEffect()
    {
        Color temp = _spriteRender.color;
        _spriteRender.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRender.color = temp;
    }
}
