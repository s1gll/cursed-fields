using UnityEngine;

public class HoleyBoots : PassiveItem
{
    public override void ApplyPassiveEffect(PlayerStats plaerStats)
    {
        playerStats.IncreaseMoveSpeed(multiplayer);
    }
}
