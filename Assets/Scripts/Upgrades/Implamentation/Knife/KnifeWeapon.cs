using System.Collections;
using UnityEngine;

public class KnifeWeapon : Weapon
{
    private PlayerMovement _player;


    private Vector3 _direction;
    private float _intervalBetweenKnifes = 0.2f;
    protected override void Start()
    {
        base.Start();
        _player = GetComponentInParent<PlayerMovement>();

    }
    private void Upgrade()
    {
        base.Update();

    }
    protected override IEnumerator AttackProcess()
    {
        Vector2 direction = _player.GetLastMovedVector().normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        for (int i = 0; i < projectileCount; i++)
        {
            Vector3 spawnPosition = transform.position + (Vector3)direction * _intervalBetweenKnifes * i;
            Damager knife = Instantiate(projectilePrefab, spawnPosition, rotation);
            Rigidbody2D rbody = knife.GetComponent<Rigidbody2D>();
            rbody.AddForce(direction * GetCurrentShootSpeed());
            FireProjectile();
            yield return new WaitForSeconds(waitTime);
        }

    }
}
