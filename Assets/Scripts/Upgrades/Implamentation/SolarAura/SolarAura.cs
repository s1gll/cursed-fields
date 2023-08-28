using UnityEngine;

using System.Collections.Generic;
public class SolarAura : Damager
{
    private List<GameObject> _markedEnemies;
    private void Start()
    {
        _markedEnemies = new List<GameObject>();
    }
    protected override void OnTriggerEnter2D(Collider2D colission)
    {

        if (colission.CompareTag("Enemy") && !_markedEnemies.Contains(colission.gameObject))
        {
            EnemyBase enemy = colission.GetComponent<EnemyBase>();
            enemy.TakeDamage(GetCurrentDamage());

            _markedEnemies.Add(colission.gameObject);
        }
        else if (colission.CompareTag("Prop"))
        {
            if (colission.gameObject.TryGetComponent(out BreakableProp breakable) && !_markedEnemies.Contains(colission.gameObject))
            {
                breakable.TakeDamage(GetCurrentDamage());

                _markedEnemies.Add(colission.gameObject);
            }
        }
        if (_destroyAfterTime)
        {
            Destroy(gameObject, _destroyAfterSeconds);
        }
    }


}













