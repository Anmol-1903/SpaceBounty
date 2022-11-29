using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShoot : MonoBehaviour
{
    public float BulletDamage;
    private bool canShoot1;
    private bool canShoot2;
    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject bulletPrefab;
    public static float bulletForce = 50f;
    public static float Cooldown = 5f;
    public float BulletLife;
    public Text sc;
    public Slider LeftT;
    public Slider RightT;
    public static float score = 1548;
    private void Awake()
    {
        sc.text = "Score : "+ score.ToString();
        canShoot1 = true;
        canShoot2 = true;
        BulletDamage = 7;
    }
    void Update()
    {
        sc.text = "Score : " + score.ToString();
        if (Input.GetButton("Fire1") && canShoot1 && !PauseGame.isPaused)
        {
            StartCoroutine(Shoot1());
        }
        if (Input.GetButton("Fire2") && canShoot2 && !PauseGame.isPaused)
        {
            StartCoroutine(Shoot2());
        }
        LeftT.value -= Time.deltaTime;
        LeftT.maxValue = Cooldown;
        RightT.value -= Time.deltaTime;
        RightT.maxValue = Cooldown;
        PauseGame.points = score;
    }
    public IEnumerator Shoot1()
    {
        canShoot1 = false;
        LeftT.value = Cooldown;
        GameObject bullet1 = Instantiate(bulletPrefab, firepoint1.position, firepoint1.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet1, BulletLife);
        yield return new WaitForSeconds(Cooldown);
        canShoot1 = true;
    }
    public IEnumerator Shoot2()
    {
        canShoot2 = false;
        RightT.value = Cooldown;
        GameObject bullet2 = Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet2, BulletLife);
        yield return new WaitForSeconds(Cooldown);
        canShoot2 = true;
    }
}