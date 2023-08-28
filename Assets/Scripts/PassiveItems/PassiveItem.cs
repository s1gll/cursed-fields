using UnityEngine;


public abstract class PassiveItem : MonoBehaviour
{
    [SerializeField] protected float multiplayer;
    [SerializeField] protected PassiveItemScriptableObject passiveItemData;
    protected PlayerStats playerStats;
    protected virtual void Start()
    {
        playerStats = GetComponentInParent<PlayerStats>();
        multiplayer = passiveItemData.Multiplayer;
        ApplyPassiveEffect(playerStats);

    }


    public abstract void ApplyPassiveEffect(PlayerStats playerStats);
    public void UpdatePassiveItemScriptableObject(PassiveItemScriptableObject newPassiveItem)
    {
        passiveItemData = newPassiveItem;
        multiplayer = newPassiveItem.Multiplayer;
         ApplyPassiveEffect(playerStats);
    }
}
