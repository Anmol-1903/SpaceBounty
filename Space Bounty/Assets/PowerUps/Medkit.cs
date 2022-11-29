using UnityEngine;
public class Medkit : MonoBehaviour
{
    public readonly PlayerHealth PH;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EnemySpawn.currentPower--;
            PlayerHealth.heal(50);
        }
    }
}