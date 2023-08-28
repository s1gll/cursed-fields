using UnityEngine;

public class FuryCrystal :PassiveItem
{
      public override void ApplyPassiveEffect(PlayerStats playerStats)
      {
        playerStats.IncreaseMight(multiplayer);
    
      }
 
}
