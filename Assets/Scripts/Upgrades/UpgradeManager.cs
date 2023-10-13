using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradesUIManager _uiManager;
    [SerializeField] private HUD _hudManager;
    [SerializeField] private PlayerItems _playerItems;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioSource _upgradeAppliedSound;

    [SerializeField] private Upgrade[] _upgrades;

    [SerializeField] private List<Upgrade> _availableUpgrades = new List<Upgrade>();

    [SerializeField] private List<Upgrade> _selectedWeaponUpgrades = new List<Upgrade>();
    [SerializeField] private List<Upgrade> _selectedPassiveItemUpgrades = new List<Upgrade>();

    [SerializeField] private List<Upgrade> _selectedWeaponLevelUpgrades = new List<Upgrade>();
    [SerializeField] private List<Upgrade> _selectedPassiveItemLevelUpgrades = new List<Upgrade>();

    public List<Upgrade> SelectedWeaponUpgrades => _selectedWeaponUpgrades;
    public List<Upgrade> SelectedPassiveItemUpgrades => _selectedPassiveItemUpgrades;


    private const int _maxUpgradesCount = 3;

    private void Awake()
    {
        _availableUpgrades.AddRange(_upgrades);
    }

    public void Suggest()
    {
        if (_availableUpgrades.Count > 0)
        {

            _gameManager.ChangeState(GameState.LevelUp);
            _uiManager.Show(_availableUpgrades, _playerItems);
        }
    }

    private bool CanAddWeaponUpgrade()
    {
        return _selectedWeaponUpgrades.Count < _maxUpgradesCount;
    }

    private bool CanAddPassiveItem()
    {
        return _selectedPassiveItemUpgrades.Count < _maxUpgradesCount;
    }

    public void AddWeaponUpgrade(Upgrade upgrade)
    {
        WeaponUpgrade weaponUpgrade = upgrade as WeaponUpgrade;
        if (weaponUpgrade != null && CanAddWeaponUpgrade())
        {
            _selectedWeaponUpgrades.Add(weaponUpgrade);
            _availableUpgrades.Remove(weaponUpgrade);
            if (_selectedWeaponUpgrades.Count == _maxUpgradesCount)
            {

                _availableUpgrades.RemoveAll(u => u is WeaponUpgrade);
            }
            _hudManager.AddWeaponUpgrade(weaponUpgrade);
        }

    }

    public void AddPassiveItem(Upgrade upgrade)
    {
        PassiveItemUpgrade passiveItemUpgrade = upgrade as PassiveItemUpgrade;
        if (passiveItemUpgrade != null && CanAddPassiveItem())
        {
            _selectedPassiveItemUpgrades.Add(passiveItemUpgrade);
            _availableUpgrades.Remove(passiveItemUpgrade);
            if (_selectedPassiveItemUpgrades.Count == _maxUpgradesCount)
            {

                _availableUpgrades.RemoveAll(u => u is PassiveItemUpgrade);
            }
            _hudManager.AddPassiveItem(passiveItemUpgrade);
        }

    }

    public void OnUpgradeApplied(Upgrade appliedUpgrade)
    {

        Helper.PlaySound(_upgradeAppliedSound);
        _uiManager.Hide();
        _gameManager.ChangeState(GameState.Gameplay);
        _availableUpgrades.Remove(appliedUpgrade);

        if (appliedUpgrade is WeaponUpgrade weaponUpgrade)
        {
            AddWeaponUpgrade(weaponUpgrade);


            if (weaponUpgrade.NextLevelPrefab != null && weaponUpgrade.NextLevelPrefab is WeaponLevelUpgrade weaponLevelUpgrade)
            {
                _selectedWeaponLevelUpgrades.Add(weaponLevelUpgrade);
                _availableUpgrades.Add(weaponLevelUpgrade);
            }
        }
        else if (appliedUpgrade is PassiveItemUpgrade passiveItemUpgrade)
        {
            AddPassiveItem(passiveItemUpgrade);


            if (passiveItemUpgrade.NextLevelPrefab != null && passiveItemUpgrade.NextLevelPrefab is PassiveItemLevelUpgrade passiveItemLevelUpgrade)
            {
                _selectedPassiveItemLevelUpgrades.Add(passiveItemLevelUpgrade);
                _availableUpgrades.Add(passiveItemLevelUpgrade);
            }
        }
        else if (appliedUpgrade is WeaponLevelUpgrade weaponLevelUpgraded)
        {
            _selectedWeaponLevelUpgrades.Add(appliedUpgrade);

            if (weaponLevelUpgraded.NextLevelPrefab != null && weaponLevelUpgraded.NextLevelPrefab is WeaponLevelUpgrade weaponLevelUpgrade)
            {
                _selectedWeaponLevelUpgrades.Add(weaponLevelUpgrade);
                _availableUpgrades.Add(weaponLevelUpgrade);
            }
        }

        else if (appliedUpgrade is PassiveItemLevelUpgrade passiveItemLevelUpgraded)
        {
            _selectedPassiveItemLevelUpgrades.Add(appliedUpgrade);

            if (passiveItemLevelUpgraded.NextLevelPrefab != null && passiveItemLevelUpgraded.NextLevelPrefab is PassiveItemLevelUpgrade passiveItemLevelUpgrade)
            {
                _selectedPassiveItemLevelUpgrades.Add(passiveItemLevelUpgrade);
                _availableUpgrades.Add(passiveItemLevelUpgrade);
            }
        }


    }
}






