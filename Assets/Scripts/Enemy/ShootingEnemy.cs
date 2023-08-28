using UnityEngine;

public class ShootingEnemy : Enemy
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _shootSpeed;
    private float _shootTimer;
    protected override void Update()
    {
        base.Update();
        Shoot();
    }
    private void Shoot()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= _shootInterval)
        {
            _shootTimer = 0;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            Vector3 direction = (target.transform.position - transform.position).normalized;

            rbody.AddForce(direction * _shootSpeed);
        }
    }
}