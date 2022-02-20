using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float starttime = 0;
    public float distance;
    public float damagePistol = 20;
    public LayerMask whatIsSolid;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damagePistol);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        starttime += 1 * Time.deltaTime;
        if (starttime >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
