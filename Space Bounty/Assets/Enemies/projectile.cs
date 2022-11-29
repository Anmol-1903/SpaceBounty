using UnityEngine;
public class projectile : MonoBehaviour
{
    PlayerHealth PH;
    public float EnemyBulletLife = 2f;
    public float speed;
    private Transform Player;
    private Vector2 target;
    public float EnemyDamage = 1;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PH.TakeDamage(EnemyDamage * EnemySpawn.difficulty);
            Destroy(gameObject);
            Debug.Log("You Took Damage");
            //other.gameObject.GetComponent<PlayerHealth>().TakeDamage(EnemyDamage[Random.Range(0, EnemyDamage.Length)]);
            
            /*
             BUG !! -- Enemy Bullet Destroys Player -- !! BUG
             */
        }
    }
}