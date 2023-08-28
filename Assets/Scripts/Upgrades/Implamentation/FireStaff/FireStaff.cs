using System.Collections;
using UnityEngine;

public class FireStaff : Weapon
{

    private float _angleDeviation = 30f;
    private float _angleDivision = 2f;


    protected override void Update()
    {
        base.Update();
    }

    protected override IEnumerator AttackProcess()
    {

        Vector3 randomDirection = Random.insideUnitCircle.normalized; // Одно случайное направление.
        float angleIncrement = _angleDeviation / (projectileCount - 1); // Расчет угла между файерболлами.

        for (int i = 0; i < projectileCount; i++)
        {
            // Применяем отклонение к направлению для каждого файерболла.
            Vector3 direction = Quaternion.Euler(0, 0, -_angleDeviation / _angleDivision + i * angleIncrement) * randomDirection;
            Damager fireball = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            fireball.Launch(direction * GetCurrentShootSpeed());
        }
        FireProjectile();
        yield return new WaitForSeconds(waitTime);
    }
}
