using System.Collections.Generic;
using UnityEngine;
public class UpgradesUIManager : MonoBehaviour
{
  [SerializeField] private UpgradeUI _upgradeUIprefab;
  [SerializeField] private UpgradeManager _upgradeManager;



  private List<Upgrade> _remainingUpgrades = new List<Upgrade>();

  public void Show(List<Upgrade> upgrades, PlayerItems playerItems)
  {
    gameObject.SetActive(true);
    foreach (Transform child in transform)
    {
      Destroy(child.gameObject);
    }

    _remainingUpgrades.Clear();
    _remainingUpgrades.AddRange(upgrades);

    // Randomly select 3 upgrades to show
    int upgradesToShow = Mathf.Min(3, _remainingUpgrades.Count);
    for (int i = 0; i < upgradesToShow; i++)
    {
      int randomIndex = Random.Range(0, _remainingUpgrades.Count);
      var selectedUpgrade = _remainingUpgrades[randomIndex];
      _remainingUpgrades.RemoveAt(randomIndex);

      var ui = Instantiate(_upgradeUIprefab, transform);
      ui.Setup(selectedUpgrade.Title, selectedUpgrade.Description, selectedUpgrade.Level, selectedUpgrade.Icon, () => OnClickApply(selectedUpgrade, playerItems));
    }
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }

  private void OnClickApply(Upgrade upgrade, PlayerItems playerItems)
  {
    upgrade.Apply(playerItems);
    _upgradeManager.OnUpgradeApplied(upgrade);
    _remainingUpgrades.Remove(upgrade); 
  }
}