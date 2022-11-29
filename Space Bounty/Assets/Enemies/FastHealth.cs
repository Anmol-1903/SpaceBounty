using UnityEngine;
public class FastHealth : MonoBehaviour
{
    public float enemyHealthF = 0.75f * EnemySpawn.difficulty;
    public void dealDamageF(float D)
    {
        enemyHealthF -= D;
        if (enemyHealthF <= 0)
        {
            Destroy(gameObject);
            EnemySpawn.currentAmt--;
            PlayerShoot.score += 1.2f * EnemySpawn.difficulty;
        }
    }
}