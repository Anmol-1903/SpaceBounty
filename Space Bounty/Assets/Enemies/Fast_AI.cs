using UnityEngine;
public class Fast_AI : MonoBehaviour
{
    public float Fast_speed;
    public Transform Player;
    private Rigidbody2D rb;
    void Start()
    {
        Fast_speed = (PlayerMove.speed);
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Fast_speed * Time.deltaTime);
        Vector3 direction = Player.position - transform.position;
        float EnemyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = EnemyAngle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage((EnemySpawn.difficulty * EnemySpawn.difficulty) / 10f);
            EnemySpawn.currentAmt--;
            Destroy(gameObject);
            PlayerShoot.score += 2;
            Debug.Log("Enemy Removed");
        }

    }
}