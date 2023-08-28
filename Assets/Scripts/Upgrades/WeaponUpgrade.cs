using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon Upgrade", menuName = "Upgrade System/Weapon Upgrade", order =1)]
public class WeaponUpgrade : Upgrade
{
    [SerializeField] private GameObject _weaponPrefab;

    public override void Apply(PlayerItems playerItems)
    {
        var weapon = Instantiate(_weaponPrefab, playerItems.transform.position, Quaternion.identity);
        weapon.transform.SetParent(playerItems.transform, true);

    }
}