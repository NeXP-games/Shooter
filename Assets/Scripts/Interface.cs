using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public GameObject interfaceA;
    public Text ammo;
    public Text moneycount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = $"{Player.pistolammomag} / {Player.inventorypistolammo}";
        moneycount.text = $"{Player.money} $";
    }
}
