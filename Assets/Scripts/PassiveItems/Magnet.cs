using UnityEngine;

public class Magnet : PassiveItem
{
    public override void ApplyPassiveEffect(PlayerStats playertats)
      {
        playerStats.IncreaseMagnet(multiplayer);
      }
}
