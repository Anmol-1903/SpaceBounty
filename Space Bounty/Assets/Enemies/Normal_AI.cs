using UnityEngine;
public class Normal_AI : MonoBehaviour
{
    public float Normal_speed = 6f;
    public Transform Player;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {        
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Normal_speed * Time.deltaTime * (EnemySpawn.difficulty/10));
        Vector3 direction = Player.position - transform.position;
        float EnemyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = EnemyAngle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((EnemySpawn.difficulty * EnemySpawn.difficulty) / 5);
            PlayerShoot.score += 5;
            EnemySpawn.currentAmt--;
            Destroy(gameObject);
            Debug.Log("Enemy Removed");
        }

    }
}