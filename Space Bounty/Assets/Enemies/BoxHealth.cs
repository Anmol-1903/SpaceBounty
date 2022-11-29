using UnityEngine;
public class BoxHealth : MonoBehaviour
{
    public float enemyHealthB = 1.2f * EnemySpawn.difficulty;
    public void dealDamageB(float D)
    {
        enemyHealthB -= D;
        if (enemyHealthB <= 0)
        {
            Destroy(gameObject);
            EnemySpawn.currentAmt--;
            PlayerShoot.score += EnemySpawn.difficulty;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((EnemySpawn.difficulty * EnemySpawn.difficulty) / 2);
            PlayerShoot.score += 20;
            EnemySpawn.currentAmt--;
            Destroy(gameObject);
            Debug.Log("Enemy Removed");
        }
    }
}