using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image _upgradeIconPrefab;
    [SerializeField] private Transform _weaponUpgradeIconParent;
    [SerializeField] private Transform _passiveItemIconParent;


    [SerializeField] private List<Upgrade> _selectedWeaponUpgrades = new List<Upgrade>();
    [SerializeField] private List<Upgrade> _selectedPassiveItemUpgrades = new List<Upgrade>();
    private int _selectedPassiveItemUpgrade;
    private int _selectedWeaponUpgrade;

    public void AddWeaponUpgrade(Upgrade upgrade)
    {
        _selectedWeaponUpgrades.Add(upgrade);
        _selectedWeaponUpgrade++;
        UpdateHUD();
    }

    public void AddPassiveItem(Upgrade upgrade)
    {
        _selectedPassiveItemUpgrades.Add(upgrade);
        _selectedPassiveItemUpgrade++;
        UpdateHUD();
    }



    private void UpdateHUD()
    {
        UpdateUpgradeIcons(_selectedWeaponUpgrades, _weaponUpgradeIconParent);
        UpdateUpgradeIcons(_selectedPassiveItemUpgrades, _passiveItemIconParent);
    }

  private void UpdateUpgradeIcons(List<Upgrade> upgrades, Transform parent)
{
   
    foreach (Transform child in parent)
    {
        Destroy(child.gameObject);
    }

    foreach (var upgrade in upgrades)
    {
        var icon = Instantiate(_upgradeIconPrefab, parent);
        icon.GetComponent<Image>().sprite = upgrade.Icon;
    }
}
}


