using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Upgrade System/Weapon Data", order = 3)]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _shootSpeed;
    [SerializeField] private float _waitTime = 0.25f;

    [SerializeField] private int _projectileCount;
   
    [SerializeField] private Damager _projectilePrefab;

    public int ProjectileCount => _projectileCount;
    public Damager ProjectilePrefab => _projectilePrefab;
      public float ShootInterval => _shootInterval;
    public float ShootSpeed => _shootSpeed;
    public float WaitTime => _waitTime;




}

