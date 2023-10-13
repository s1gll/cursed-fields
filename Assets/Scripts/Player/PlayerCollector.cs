using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private float _pullSpeed;
    [SerializeField] protected AudioSource pickupSound;
    private PlayerStats _player;
    private CircleCollider2D _playerCollector;

    private void Start()
    {
        _player = GetComponentInParent<PlayerStats>();
        _playerCollector = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        _playerCollector.radius = _player.Magnet;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (_playerCollector.bounds.center - col.transform.position).normalized;

            rb.AddForce(forceDirection * _pullSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
            Helper.PlaySound(pickupSound);
        }
    }
}
