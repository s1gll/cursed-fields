
using UnityEngine;

public class Whip : Damager
{
   [SerializeField] private Vector2 _whipAttackSize=new Vector2(5.5f,1.6f);
 
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Collider2D[] targets = Physics2D.OverlapBoxAll(transform.position, _whipAttackSize,0f);
        foreach (var target in targets)
        {
            TryDoDamage(target);
        }
      
    }
}
