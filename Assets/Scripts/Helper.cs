using UnityEngine;

public static class Helper
{
    public static Enemy FindClosestEnemy(EnemiesSpawner spawner, Transform transform)
    {
        Enemy clossetEnemy = null;
        float minDistance = float.MaxValue;
        foreach (var enemy in spawner.SpawnedEnemies)
        {
            float distance = (enemy.transform.position - transform.position).magnitude;
            if (distance < minDistance)
            {
                clossetEnemy = enemy;
                minDistance = distance;
            }
        }
        return clossetEnemy;
    }
}
