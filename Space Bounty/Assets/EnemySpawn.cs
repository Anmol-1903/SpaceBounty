using UnityEngine;
public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject normalEnemy;
    public GameObject fastEnemy;
    public GameObject circleEnemy;
    public GameObject boxEnemy;

    public GameObject randPower;
    public GameObject reload;
    public GameObject hp;

    public float powerupchance = 100f;

    private float choice,temp2;
    public static float currentPower = 0f;
    public float maxPower = 5f;
    public float maxEnemy = 5f;
    public static float currentAmt = 0f;
    public float normalChances;
    public float fastChances;
    public float circleChances;
    public float boxChances;
    public GameObject randEnemy;
    public static float difficulty = 10f;
    public float enemySpawnCooldown;
    void Start()
    {
        enemySpawnCooldown = 10f;
        InvokeRepeating(nameof(NewEnemy), enemySpawnCooldown, 1);
    }
    private void Update()
    {
        Debug.Log(difficulty);
        if (PlayerShoot.score >= 0 && PlayerShoot.score < 100)
        {
            difficulty = 10;
            PlayerMove.speed = 15;
            PlayerShoot.bulletForce = 50;
        }
        else if (PlayerShoot.score >= 100 && PlayerShoot.score < 200)
        {
            difficulty = 11;
            PlayerMove.speed = 17;
            PlayerShoot.bulletForce = 54;
        }
        else if(PlayerShoot.score >= 200 && PlayerShoot.score < 400)
        {
            difficulty = 13;
            PlayerMove.speed = 19;
            PlayerShoot.bulletForce = 58;
        }
        else if(PlayerShoot.score >= 400 && PlayerShoot.score < 700)
        {
            difficulty = 15;
            PlayerMove.speed = 21;
            PlayerShoot.bulletForce = 62;
        }
        else if(PlayerShoot.score >= 700 && PlayerShoot.score < 1000)
        {
            difficulty = 17;
            PlayerMove.speed = 23;
            PlayerShoot.bulletForce = 66;
        }
        else if(PlayerShoot.score >= 1000 && PlayerShoot.score < 1500)
        {
            difficulty = 19;
            PlayerMove.speed = 25;
            PlayerShoot.bulletForce = 70;
        }
        else
        {
            difficulty = 20;
            PlayerMove.speed = difficulty + 6;
            PlayerShoot.bulletForce = (PlayerMove.speed * 2) + 20;
        }
        if (difficulty <= 11)
        {
            normalChances = 100f;
            fastChances = 10f;
            circleChances = 0f;
            boxChances = 0f;
            maxEnemy = 7f;
        }
        else if (difficulty <= 13)
        {
            normalChances = 100f;
            fastChances = 30f;
            circleChances = 5f;
            boxChances = 0f;
            maxEnemy = 10f;
        }
        else if (difficulty <= 15)
        {
            normalChances = 100f;
            fastChances = 40f;
            circleChances = 10f;
            boxChances = 0f;
            maxEnemy = 14f;
        }
        else if (difficulty <= 17)
        {
            normalChances = 100f;
            fastChances = 75f;
            circleChances = 25f;
            boxChances = 5f;
            maxEnemy = 19f;
        }
        else if (difficulty <= 19)
        {
            normalChances = 100f;
            fastChances = 60f;
            circleChances = 30f;
            boxChances = 10f;
            maxEnemy = 25f;
        }
        else
        {
            normalChances = 0f;
            fastChances = 0f;
            circleChances = 0f;
            boxChances = 0f;
            Debug.Log("All Enemies Now Have Equal Chances Of Spawning. Good Luck >:]");
            Debug.Log("Chaos Begins!!");
        }
    }
    public void NewEnemy()
    {
        if(currentPower < maxPower)
        {
            float temp3 = Random.Range(1,100);
            if(temp3 - 5 <= 0)
            {
                randPower = hp;
            }
            else if (temp3 - 10 <= 0)
            {
                randPower = reload;
            }
            if(randPower != null)
            {
                int randSpawn = Random.Range(0, spawnPoint.Length);
                Instantiate(randPower, spawnPoint[randSpawn].position, Quaternion.identity);
                currentPower++;
            }
            Debug.Log("POWERUP SPAWNED => "+ temp3);
        }
        if (currentAmt < maxEnemy)
        {
            choice = Random.Range(1, 100);
            if (choice - boxChances <= 0)
            {
                randEnemy = boxEnemy;
                currentAmt++;
            }
            else if (choice - circleChances <= 0)
            {
                randEnemy = circleEnemy;
                currentAmt++;
            }
            else if (choice - fastChances <= 0)
            {
                randEnemy = fastEnemy;
                currentAmt++;
            }
            else if (choice - normalChances <= 0)
            {
                randEnemy = normalEnemy;
                currentAmt++;
            }
            else
            {
                float temp = Random.Range(1, 4);
                if (temp == 1)
                {
                    randEnemy = normalEnemy;
                }
                else if (temp == 2)
                {
                    randEnemy = fastEnemy;
                }
                else if (temp == 3)
                {
                    randEnemy = circleEnemy;
                }
                else
                {
                    randEnemy = boxEnemy;
                }
                currentAmt = 0;
            }
            int randSpawn = Random.Range(0, spawnPoint.Length);
            Instantiate(randEnemy, spawnPoint[randSpawn].position, transform.rotation);
            Debug.Log("New Enemy Spawned!! (" + choice + ")");
        }
    }
}