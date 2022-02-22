using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool paused = false;
    public GameObject Panel;
    public GameObject PanelDead;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
                Panel.SetActive(true);
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
                Panel.SetActive(false);
            }    
        }
        if (Player.currentHealth == 0)
        {
            paused = true;
            Time.timeScale = 0;
            PanelDead.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        paused = false;
        Time.timeScale = 1;
        Player.currentHealth = Player.maxHealth;
        Instantiate(player);
    }

    public void inMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void inWindows()
    {
        Application.Quit();
    }

    public void resume()
    {
        paused = false;
        Time.timeScale = 1;
        Panel.SetActive(false);
    }
}
