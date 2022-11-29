using UnityEngine;
public class QuickReload : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EnemySpawn.currentPower--;
            PlayerShoot.Cooldown -= (PlayerShoot.Cooldown/10);
        }
    }
}