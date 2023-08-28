using System.Collections;
using UnityEngine;

public class GearLaunch : Weapon
{
 
    protected override void Update()
    {
        base.Update();
    }
    protected override IEnumerator AttackProcess()
    {
        Damager gear = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
          FireProjectile();
        yield return new WaitForSeconds(waitTime);
    }
}
