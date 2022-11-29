using UnityEngine;
public class NormalHealth : MonoBehaviour
{
    public float enemyHealthN = 1f * EnemySpawn.difficulty;
    public void dealDamageN(float D)
    {
        enemyHealthN -= D;
        if (enemyHealthN <= 0)
        {
            Destroy(gameObject);
            EnemySpawn.currentAmt--;
            PlayerShoot.score += EnemySpawn.difficulty;
        }
    }
}