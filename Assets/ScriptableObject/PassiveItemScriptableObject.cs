using UnityEngine;
[CreateAssetMenu(fileName = "New Passive Item Data", menuName = "Upgrade System/Passive Item Data", order =6)]
public class PassiveItemScriptableObject : ScriptableObject
{
   [SerializeField] private float _multiplayer;
   public float Multiplayer => _multiplayer;
}
