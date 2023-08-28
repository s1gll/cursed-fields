using UnityEngine;

public class ExperiencePickup : Pickup, ICollectible
{

    [SerializeField] private int _experience;
    public void Collect()
    {
        

        LevelSystem _levelSystem = FindObjectOfType<LevelSystem>();
        _levelSystem.IncreaseExperience(_experience);
    }
}
