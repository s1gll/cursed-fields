using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rbody;

    [SerializeField] private float _damage;

    [SerializeField] protected bool _destroyOnHit;
    [SerializeField] protected bool _destroyAfterTime = false;

    [SerializeField] protected float _destroyAfterSeconds = 2f;




    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (TryDoDamage(collision) && _destroyOnHit)
        {
            Destroy(gameObject);
        }
        if (_destroyAfterTime)
        {
            Destroy(gameObject, _destroyAfterSeconds);
        }

    }

    protected bool TryDoDamage(Collider2D collision)
    {
        bool hasEnemyHealth = collision.TryGetComponent<EnemyBase>(out var enemy);
        bool hasPlayerHealth = collision.TryGetComponent<PlayerStats>(out var player);
        bool hasPropHealth = collision.TryGetComponent<BreakableProp>(out var prop);


        bool otherHealth = !collision.CompareTag(tag);

        if (otherHealth)
        {
            if (hasEnemyHealth)
            {
                enemy.TakeDamage(GetCurrentDamage());
                return true;
            }
            else if (hasPropHealth)
            {
                prop.TakeDamage(GetCurrentDamage());
                return true;
            }
            else if (hasPlayerHealth && !hasEnemyHealth)
            {
                player.TakeDamage(_damage);
                return true;
            }

        }

        return false;
    }

    public void Launch(Vector3 force)
    {
        _rbody.AddForce(force);
        transform.right = force;


    }
    public float GetCurrentDamage()
    {
        return _damage * FindObjectOfType<PlayerStats>().Might;
    }
}

