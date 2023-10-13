using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemy Waves/Wave", order = 1)]
public class WaveScriptableObject : ScriptableObject
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemyCount;

    public Enemy EnemyPrefab => _enemyPrefab;
    public int EnemyCount => _enemyCount;
}
