
using UnityEngine;

public class Magicball : Damager
{
    [SerializeField] private float _aoe;
 
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, _aoe);
        bool anyDamaged = false;
        foreach (var target in targets)
        {
            anyDamaged |= TryDoDamage(target);
        }
        if (anyDamaged && _destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
