using UnityEngine;

using System.Collections.Generic;
public class SolarAura : Damager
{
    private List<GameObject> _markedEnemies;
    private void Start()
    {
        _markedEnemies = new List<GameObject>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") && !_markedEnemies.Contains(collision.gameObject))
        {
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            enemy.TakeDamage(GetCurrentDamage());

            _markedEnemies.Add(collision.gameObject);
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProp breakable) && !_markedEnemies.Contains(collision.gameObject))
            {
                breakable.TakeDamage(GetCurrentDamage());

                _markedEnemies.Add(collision.gameObject);
            }
        }
        if (_destroyAfterTime)
        {
            Destroy(gameObject, _destroyAfterSeconds);
        }
    }


}













