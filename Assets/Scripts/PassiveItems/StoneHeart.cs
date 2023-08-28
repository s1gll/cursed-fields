using UnityEngine;

public class StoneHeart : PassiveItem
{
  public override void ApplyPassiveEffect(PlayerStats playerStats)
      {
        playerStats.IncreaseRegenerate(multiplayer);
      }
}
