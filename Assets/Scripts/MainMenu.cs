using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Panel;
    public Button Sound;
    public Sprite SoundOnsprite;
    public Sprite SoundOffsprite;
    public bool s;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void newGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SettingsBT()
    {
        Panel.SetActive(true);
    }
    public void Back()
    {
        Panel.SetActive(false);
    }

    public void Musicswitch()
    {
        
    }
    public void Soundswitch()
    {
        if (s)
        {
            Sound.GetComponent<Image>().sprite = SoundOffsprite;
            s = false;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = SoundOnsprite;
            s = true;
        }
    }
}
