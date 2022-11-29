using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public Image knob;
    public Color low;
    public Color high;
    public Vector3 offset;
    public float maxHealth = 100f;
    public static float currentHealth;
    public float deathTime = 0.3f;
    public bool dead = false;
    void Awake()
    {
        currentHealth = maxHealth;
        SetHealth(currentHealth, maxHealth);
    }
    private void Update()
    {
        SetHealth(currentHealth, maxHealth);
        if (dead)
        {
            if(Time.timeScale <= 0.1f)
            {
                Time.timeScale = 0.1f;
                if(deathTime <= 0)
                {
                    PauseGame.isDead = dead;
                }
                else
                {
                    deathTime -= Time.deltaTime;
                }
            }
            else
            {
                Time.timeScale -= Time.deltaTime;
            }
        }
    }
    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
        knob.color = Color.Lerp(low, high, slider.normalizedValue);
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        //Debug.Log("Health Set To => "+ currentHealth);
    }
    public void TakeDamage(float DamageTaken)
    {
        currentHealth -= DamageTaken;
        if (currentHealth <= 0f)
        {
            slider.fillRect.GetComponentInChildren<Image>().color = Color.grey;
            SetHealth(0, maxHealth);
            dead = true;
        }
        else
        {
            SetHealth(currentHealth, maxHealth);
        }
    }
    public static void heal(float amt)
    {
        currentHealth += amt;
        if(currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}