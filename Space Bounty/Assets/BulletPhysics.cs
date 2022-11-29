using UnityEngine;
public class BulletPhysics : MonoBehaviour
{
    public float BulletDamage = 7f;
    public GameObject bullet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxEnemy"))
        {
            collision.gameObject.GetComponent<BoxHealth>().dealDamageB(BulletDamage * EnemySpawn.difficulty / 10);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("NormalEnemy"))
        {
            collision.gameObject.GetComponent<NormalHealth>().dealDamageN(BulletDamage * EnemySpawn.difficulty / 10);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("FastEnemy"))
        {
            collision.gameObject.GetComponent<FastHealth>().dealDamageF(BulletDamage * EnemySpawn.difficulty / 10);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("CircleEnemy"))
        {
            collision.gameObject.GetComponent<CircleHealth>().dealDamageC(BulletDamage * EnemySpawn.difficulty / 10);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}