using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    public static bool magazine = false;
    public GameObject panelMAG;
    public GameObject panelMAGW; //Weapon
    public GameObject panelMAGS; //Skills
    public GameObject panelAlertMoney;
    public GameObject panelAlertHP;
    public Button btnWeaponMAG;
    public Button btnSkillsMAG;
    public Button btnExitMAG;
    public Text textalertMoney;

    public HealthBar healthBar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void gobuyWeapon()
    {
        panelMAGW.SetActive(true);
        panelMAG.SetActive(false);
    }

    public void gobuySkills()
    {
        panelMAGS.SetActive(true);
        panelMAG.SetActive(false);
    }

    public void exitMag()
    {
        panelMAG.SetActive(false);
    }

    public void backMAGW()
    {
        panelMAGW.SetActive(false);
        panelMAG.SetActive(true);
    }

    public void backMAGS()
    {
        panelMAGS.SetActive(false);
        panelMAG.SetActive(true);
    }

    public void buyPistolAmmo()
    {
        if (Player.money >= 50)
        {
            Player.money -= 50;
            Player.inventorypistolammo += 10;
        }
        if (Player.money < 50)
        {
            panelAlertMoney.SetActive(true);
        }
    }

    public void buyHP()
    {
        if (Player.money >= 1000)
        {
            if (Player.currentHealth != Player.maxHealth)
            {
                Player.money -= 1000;
                Player.currentHealth += Player.maxHealth - Player.currentHealth;
                healthBar.SetHealth(Player.currentHealth);
            }
            else
            {
                panelAlertHP.SetActive(true);
            }
        }
        else
        {
            panelAlertMoney.SetActive(true);
            textalertMoney.text = $"You are missing {1000 - Player.money} $";
        }
       
    }

    public void closealertMoney()
    {
        panelAlertMoney.SetActive(false);
    }

    public void closealertHP()
    {
        panelAlertHP.SetActive(false);
    }
}
