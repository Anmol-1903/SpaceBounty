using UnityEngine;
public class CircleHealth : MonoBehaviour
{
    public float enemyHealthC = 0.85f * EnemySpawn.difficulty;
    public void dealDamageC(float D)
    {
        enemyHealthC -= D;
        if (enemyHealthC <= 0)
        {
            Destroy(gameObject);
            EnemySpawn.currentAmt--;
            PlayerShoot.score += EnemySpawn.difficulty;
        }
    }
}