using System.Collections;
using UnityEngine;

public class StartWeapon : Weapon
{
    [SerializeField] private EnemiesSpawner _spawner;

    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator AttackProcess()
    {
        Enemy closest = Helper.FindClosestEnemy(_spawner, transform);
        if (closest)
        {
            Damager bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            Vector3 direction = (closest.transform.position - transform.position).normalized;

            rbody.AddForce(direction * shootSpeed);
        FireProjectile();
        }
        yield return new WaitForSeconds(waitTime);
    }

}
