using UnityEngine;


public class Enemy : EnemyBase
{
  private EnemyKnockback knockbackController;

  protected override void Start()
  {
    base.Start();
    knockbackController = GetComponent<EnemyKnockback>();
    OnTakeDamage.AddListener(ApplyKnockback);
  }

  private void ApplyKnockback()
  {
    Vector2 knockbackDirection = (transform.position - target.position).normalized;
    knockbackController.ApplyKnockback(knockbackDirection);
  }
  protected virtual void Update()
  {
    Vector3 direction = (target.position - transform.position).normalized;
    transform.position += direction * _moveSpeed * Time.deltaTime;
    CheckForFlipping(direction);
  }
  protected override void OnDead()
  {
    Instantiate(pickup, transform.position, Quaternion.identity);
    OnDied.Invoke();

    Destroy(gameObject);

  }
}

