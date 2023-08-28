using UnityEngine;

public class Bracer : PassiveItem
{
    public override void ApplyPassiveEffect(PlayerStats playertats)
      {
        playerStats.IncreaseProjectileSpeed(multiplayer);
      }
}
