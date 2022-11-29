using UnityEngine;
public class Box_AI : MonoBehaviour
{
    public float[] Box_speed = { 9f, 10f, 11f };
    public float[] stoppingDistance = { 1.0f, 1.3f, 1.6f, 1.9f, 2.2f , 2.5f };
    private float timeBtwShots;
    public float startTimeBtwShots = 2f;
    public GameObject projectile;
    public Transform Player;
    private Rigidbody2D rb;
    public Vector2 target;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance[Random.Range(0, stoppingDistance.Length)])
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Box_speed[Random.Range(0, Box_speed.Length)] * Time.deltaTime * (EnemySpawn.difficulty / 10));
        }
        else if (Vector2.Distance(transform.position, Player.position) < stoppingDistance[Random.Range(0, stoppingDistance.Length)])
        {
            transform.position = this.transform.position;
        }
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile , transform.position , Quaternion.identity);
            timeBtwShots = startTimeBtwShots * 10 / EnemySpawn.difficulty;
            Debug.Log("Bullet Shot");
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        Vector3 direction = Player.position - transform.position;
        float EnemyAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = EnemyAngle;
    }
}