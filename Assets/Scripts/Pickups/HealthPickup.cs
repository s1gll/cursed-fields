using UnityEngine;

public class HealthPickup : Pickup, ICollectible
{
    [SerializeField] private int _healthToRestore;
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(_healthToRestore);
    }
}
