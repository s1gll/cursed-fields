using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _center;
    [SerializeField] private float _maxDistanceFromPlayer = 30f;
    [SerializeField] private Transform[] _spawnPoints;

    private int _killCount = 0;
    [SerializeField] private Text killCountUIText;

    [System.Serializable]
    class Wave
    {
        public Enemy enemyPrefab;
        public int countMin, countMax;
    }

    [SerializeField] private Wave[] waves;
    private int _waveIndex = 0;
    private bool HasWaves => _waveIndex < waves.Length;

    [SerializeField] private PlayerMovement _player;

    public List<Enemy> SpawnedEnemies { get; } = new List<Enemy>();

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
        }
    }

    private void Spawn()
    {
        var currentWave = waves[_waveIndex];
        int count = Random.Range(currentWave.countMin, currentWave.countMax + 1);
        for (int i = 0; i < count; i++)
        {
            var position = _center.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
            var enemy = Instantiate(currentWave.enemyPrefab, position, Quaternion.identity);
            SpawnedEnemies.Add(enemy);

            enemy.OnDied.AddListener(() => OnEnemyDead(enemy));
        }
    }

    private void OnEnemyDead(Enemy enemy)
    {
        _killCount++;
        UpdateKillCountUI();
        SpawnedEnemies.Remove(enemy);


        if (SpawnedEnemies.Count <= 8 && HasWaves)
        {
            SpawnNextWave();
        }
    }

    private void UpdateKillCountUI()
    {
        killCountUIText.text = "Killed Enemies: " + _killCount.ToString();
    }
}

