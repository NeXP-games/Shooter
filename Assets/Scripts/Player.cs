using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float speed;
    public float energy;
    public float stamina;
    public float maxstamina = 100;
    public float runSpeed;
    public float regSpeed;
    public float offset;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShot;

    public static float currentHealth;
    public static float maxHealth = 100;

    public static int money = 0;

    public static int pistolammomag = 7;
    public static int maxpistolammo = 7;
    public static int inventorypistolammo = 21;

    public HealthBar healthBar;
    public StaminaBar staminaBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        stamina = maxstamina;
        healthBar.SetMaxHealth(maxHealth);
        staminaBar.SetMaxStamina(maxstamina);
        pistolammomag = maxpistolammo; // Switch on save atribute
        inventorypistolammo = 21; // Switch on save atribute
        speed = regSpeed;
    }

    void Update()
    {
        //Player movements
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (Pause.paused == false)
        {
            //mouse monitoring
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            //Shooting
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0) && pistolammomag != 0)
                {
                    Instantiate(bullet, shotPoint.position, transform.rotation);
                    timeBtwShots = startTimeBtwShot * 2;
                    pistolammomag--;
                    Debug.Log(pistolammomag);
                }   
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            //Shift - run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (stamina > 0)
                {
                    speed = runSpeed;
                    stamina -= energy;
                    staminaBar.SetStamina(stamina);
                }
                else
                {
                    speed = regSpeed;
                    StartCoroutine("energyCharge", 8f);
                    staminaBar.SetStamina(stamina);
                }
            }
            else
            {
                speed = regSpeed;
                if (stamina < 100)
                {
                    StartCoroutine("energyCharge", 8f);
                }
            }
            Debug.Log("Стамина: " + stamina + " Скорость: " + speed);
        }
        //reload
        if (Input.GetKeyDown(KeyCode.R) && inventorypistolammo > 0)
        {
            Invoke("reload", 2);
        }
        //dead
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //Player movements
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentHealth = currentHealth - Enemy.damageE1;
            healthBar.SetHealth(currentHealth);
        }
    }

    void reload()
    {
        inventorypistolammo -= maxpistolammo - pistolammomag;
        pistolammomag = maxpistolammo;
        Debug.Log(pistolammomag +" "+ inventorypistolammo);
    }

    IEnumerator energyCharge()
    {
        stamina += energy * (12 / 10);
        staminaBar.SetStamina(stamina);
        return null;
    }
}
