using UnityEngine;
using UnityEngine.UI;

public class DamageUIText : MonoBehaviour
{

    [SerializeField] private Text _text;
    [SerializeField] private float _displayDuration = 1.0f;

    [SerializeField] private GameObject _damageTextPrefab;

    private void Start()
    {
        Destroy(gameObject, _displayDuration);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
    public void ShowDamageText(Vector3 position, float damage)
    {
        Instantiate(_damageTextPrefab, position, Quaternion.identity);
        SetText("-" + damage.ToString());
    }
}

