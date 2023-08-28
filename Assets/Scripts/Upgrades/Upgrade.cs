using UnityEngine;

[CreateAssetMenu(fileName = " New Upgrade", menuName = "Upgrade System/Upgrade", order =0)]
public class Upgrade :ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private string _level;
    [SerializeField] private Sprite _icon;
  
    [SerializeField] private Upgrade _nextLevelPrefab;
    public string Title => _title;
    public string Description => _description;
    public string Level=>_level;
    public Sprite Icon => _icon;
    public Upgrade NextLevelPrefab => _nextLevelPrefab;
  
    public virtual void Apply(PlayerItems playerItems)
    {

    }
}