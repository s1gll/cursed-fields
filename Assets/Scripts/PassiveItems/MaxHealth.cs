using UnityEngine;

public class MaxHealth : PassiveItem
{
    public override void ApplyPassiveEffect(PlayerStats playerStats)
    {
        playerStats.IncreaseMaxHealth(multiplayer);
    }
}
