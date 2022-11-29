using UnityEngine;
public class Circle_AI : MonoBehaviour
{
    public float Circle_speed = 5f;
    public Transform Player;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Circle_speed * Time.deltaTime * (EnemySpawn.difficulty / 10));
        Vector3 direction = Player.position - transform.position;
        float EnemyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = EnemyAngle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((EnemySpawn.difficulty * EnemySpawn.difficulty) / 2);
            PlayerShoot.score += 10;
            EnemySpawn.currentAmt--;
            Destroy(gameObject);
            Debug.Log("Enemy Removed");
        }
    }
}