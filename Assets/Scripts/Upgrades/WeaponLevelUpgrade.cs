using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Level Upgrade", menuName = "Upgrade System/Weapon Level", order =2)]
public class WeaponLevelUpgrade : Upgrade
{
    [SerializeField] private WeaponScriptableObject _weaponScriptableObject;
     [SerializeField] private string _targetWeaponClassName; 
    

    public override void Apply(PlayerItems playerItems)
    {
     foreach (var weapon in playerItems.GetWeapons())
        {
            if (weapon.GetType().Name == _targetWeaponClassName)
            {
                weapon.UpdateWeaponScriptableObject(_weaponScriptableObject);
            }
        }
    }
}
