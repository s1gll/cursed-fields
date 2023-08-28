using System.Collections;
using UnityEngine;

public class FlashSpriteEffect : MonoBehaviour
{
    [SerializeField] private float _flashDuration = 0.2f;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }
    public void Flash()
    {
        StartCoroutine(FlashSprite());
    }
    public IEnumerator FlashSprite()
    {
        _spriteRenderer.color = Color.black;

        yield return new WaitForSeconds(_flashDuration);

        _spriteRenderer.color = _originalColor;
    }
}
