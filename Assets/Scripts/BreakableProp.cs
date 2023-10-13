using UnityEngine;

public class BreakableProp : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _pickupPrefab;
    [SerializeField, Range(0, 1)] private float _pickupChance = 0.25f;
    [SerializeField] private AudioSource _breakSound;

    private FlashSpriteEffect _flashSpriteEffect;

    private void Start()
    {
        _flashSpriteEffect = GetComponent<FlashSpriteEffect>();
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        Helper.PlaySound(_breakSound);
        _flashSpriteEffect.Flash();
        if (_health <= 0)
        {
            Kill();


            if (Random.value <= _pickupChance)
            {
                SpawnHealthPickup();
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void SpawnHealthPickup()
    {
        Instantiate(_pickupPrefab, transform.position, Quaternion.identity);
    }
}







