using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    public float damagePoints;
    private Rigidbody rb;
    [HideInInspector] public EnemyManager enemy;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Terrain") || 
        collision.gameObject.CompareTag("ArmouredEnemy") ||
        collision.gameObject.CompareTag("MeleeEnemy"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyManager>();

            enemy.healthPoints -= damagePoints;

            Destroy(gameObject);
        }  
    }
}