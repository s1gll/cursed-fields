
using System.Collections;
using UnityEngine;

public class SolarAuraLauncher : Weapon
{
    protected override IEnumerator AttackProcess()
    {
        Damager solarAura = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        solarAura.transform.SetParent(transform);
           FireProjectile();
        yield return new WaitForSeconds(waitTime);

    }
}
