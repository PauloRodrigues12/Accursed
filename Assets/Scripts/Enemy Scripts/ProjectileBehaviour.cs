using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject particleSystem;
    private Rigidbody rb;
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
        collision.gameObject.CompareTag("Player"))
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
