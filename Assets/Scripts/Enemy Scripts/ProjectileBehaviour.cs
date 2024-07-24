using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody rb;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //transform.localPosition += new Vector3(projectileSpeed, 0, 0) * Time.deltaTime;
        rb.velocity = transform.forward * projectileSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
            Destroy(gameObject);
    }
}
