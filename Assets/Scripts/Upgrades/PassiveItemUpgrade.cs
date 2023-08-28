using UnityEngine;
[CreateAssetMenu(fileName = "New Passive Item Upgrade", menuName = "Upgrade System/Passive Item Upgrade", order =4)]
public class PassiveItemUpgrade : Upgrade
{
    [SerializeField] private GameObject _passiveItemPrefab;
    public override void Apply(PlayerItems playerItems)
    {
        var passiveItem = Instantiate(_passiveItemPrefab, playerItems.transform.position, Quaternion.identity);
        passiveItem.transform.SetParent(playerItems.transform, true);
    }
}
