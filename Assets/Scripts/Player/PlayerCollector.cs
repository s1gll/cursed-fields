using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private float _pullSpeed;
    [SerializeField] protected AudioSource pickupSound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            rb.AddForce(forceDirection * _pullSpeed);
            pickupSound.Play();
            collectible.Collect();
        }
    }
}
