using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _center;
    [SerializeField] private float _maxDistanceFromPlayer = 30f;
     [SerializeField] private int _initialEnemiesInFields = 5;
    [SerializeField] private int _enemiesInFieldsIncrement = 2;

    private int _enemiesInFields = 5;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Text killCountUIText;

    [SerializeField] private WaveScriptableObject[] _waves;
    private int _waveIndex = 0;
    private bool HasWaves => _waveIndex < _waves.Length;

    private int _killCount = 0;
    public List<Enemy> SpawnedEnemies { get; } = new List<Enemy>();

    [SerializeField] private PlayerMovement _player;

    private void Start()
    {
        killCountUIText.text = "Killed Enemies: " + _killCount.ToString();
        SpawnNextWave();
    }

    private void Update()
    {
        foreach (var enemy in SpawnedEnemies)
        {
            float distanceToPlayer = Vector2.Distance(enemy.transform.position, _player.transform.position);

            if (distanceToPlayer > _maxDistanceFromPlayer)
            {
                enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            }
        }
    }

    private void SpawnNextWave()
    {
        if (HasWaves)
        {
            Spawn();
            _waveIndex++;
           if (_waveIndex % _initialEnemiesInFields == 0)
            {
                _initialEnemiesInFields += _enemiesInFieldsIncrement; 
            }
        }
    }

    private void Spawn()
    {
        var currentWave = _waves[_waveIndex];
        for (int i = 0; i < currentWave.EnemyCount; i++)
        {
            var position = _center.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
            var enemy = Instantiate(currentWave.EnemyPrefab, position, Quaternion.identity);
            SpawnedEnemies.Add(enemy);

            enemy.OnDied.AddListener(() => OnEnemyDead(enemy));
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _killCount++;
        UpdateKillCountUI();
        SpawnedEnemies.Remove(enemy);


        if (SpawnedEnemies.Count <= _enemiesInFields && HasWaves)
        {
            SpawnNextWave();
        }
    }

    private void UpdateKillCountUI()
    {
        killCountUIText.text = "Killed Enemies: " + _killCount.ToString();
    }
}
