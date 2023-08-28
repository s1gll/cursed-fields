using System.Collections;
using UnityEngine;

public class MagicStaff : Weapon
{
    private EnemiesSpawner _spawner;
    protected override void Start()
    {
        base.Start();
        _spawner = FindObjectOfType<EnemiesSpawner>();
    }
    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator AttackProcess()
    {
        Enemy closest = Helper.FindClosestEnemy(_spawner, transform);
            if (closest)
            {
                for (int i = 0; i < projectileCount; i++)
                {
                    Vector3 direction = (closest.transform.position - transform.position).normalized;
                    Damager magicball = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    magicball.Launch(direction * GetCurrentShootSpeed());
                    FireProjectile();
                }
            }

            yield return new WaitForSeconds(waitTime);


        }
    }
