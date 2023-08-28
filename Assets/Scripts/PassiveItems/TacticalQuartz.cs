using UnityEngine;

public class TacticalQuartz : PassiveItem
{
   public override void ApplyPassiveEffect(PlayerStats playerStats)
      {
        playerStats.IncreaseSpeedReaction(multiplayer);
      }
}
