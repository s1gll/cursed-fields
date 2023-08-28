using UnityEngine;
[CreateAssetMenu(fileName = "New Passive Item Level Upgrade", menuName = "Upgrade System/Passive Item Level", order = 5)]
public class PassiveItemLevelUpgrade : Upgrade
{

    [SerializeField] private PassiveItemScriptableObject _passiveItemScriptableObject;
    [SerializeField] private string _targetPassiveItemClassName;


    public override void Apply(PlayerItems playerItems)
    {
        foreach (var passiveItem in playerItems.GetPassiveItems())
        {
            if (passiveItem.GetType().Name == _targetPassiveItemClassName)
            {
                passiveItem.UpdatePassiveItemScriptableObject(_passiveItemScriptableObject);
            
            }
        }
    }
}
