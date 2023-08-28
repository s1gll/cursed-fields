using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected float shootInterval;
    protected float shootSpeed;
    protected float waitTime;
    private float _shootTimer;

    protected int projectileCount;

    protected Damager projectilePrefab;
    [SerializeField] private AudioSource _projectileSound;
    [SerializeField] private WeaponScriptableObject _weaponData;
    protected virtual void Start()
    {

        shootInterval = _weaponData.ShootInterval;
        shootSpeed = _weaponData.ShootSpeed;
        waitTime = _weaponData.WaitTime;

        projectileCount = _weaponData.ProjectileCount;
        projectilePrefab = _weaponData.ProjectilePrefab;
    }


    protected virtual void Update()
    {
        _shootTimer += Time.deltaTime;
        if (_shootTimer >= GetCurrentShootInterval())
        {

            _shootTimer = 0;
            StartCoroutine(AttackProcess());
          
        }
    }
    protected void FireProjectile()
    {
        _projectileSound.Play();
    }
    public void UpdateWeaponScriptableObject(WeaponScriptableObject newWeaponData)
    {
        _weaponData = newWeaponData;
        shootInterval = _weaponData.ShootInterval;
        shootSpeed = _weaponData.ShootSpeed;
        waitTime = _weaponData.WaitTime;
        projectileCount = _weaponData.ProjectileCount;
        projectilePrefab = _weaponData.ProjectilePrefab;
    }
    public float GetCurrentShootSpeed()
    {
        return shootSpeed * GetComponentInParent<PlayerStats>().ProjectileSpeed;
    }
    public float GetCurrentShootInterval()
    {
        return shootInterval * GetComponentInParent<PlayerStats>().SpeedReaction;
    }

    protected abstract IEnumerator AttackProcess();
}
