using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float offset;
    public float stoppingDistance;
    public float viewDistance;

    public float health = 100;
    public static float damageE1 = 10;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //Player monitoring
        Vector3 difference = target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        //Enemy movements
        if (Vector2.Distance(transform.position, target.position) <= viewDistance) 
        { 
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
        //Death
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damagePistol)
    {
        health -= damagePistol;
    }
}
