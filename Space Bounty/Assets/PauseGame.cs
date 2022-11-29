using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject MainMenu;
    public GameObject DeathScreen;
    public static bool isPaused = true;
    public static bool isDead = false;
    public static float points, survived = 0f;
    public Text pts, tm;
    private void Start()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (isDead)
        {
            Death();
        }
        else
        {
            survived += Time.fixedDeltaTime;
        }
    }
    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isDead = false;
    }
    public void Main()
    {
        SceneManager.LoadScene("SampleScene");
        DeathScreen.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        isDead = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        DeathScreen.SetActive(false);
        MainMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        isDead = false;
    }
    public void Play()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isDead = false;
    }
    public void Death()
    {
        DeathScreen.SetActive(true);
        tm.text = "You Survived " + Mathf.Round(survived).ToString() + " Seconds";
        pts.text = "Score : " + points.ToString();
        Time.timeScale = 0f;
        isPaused = true;
    }
}