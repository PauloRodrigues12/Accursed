using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movingDirection = new Vector3(xMovement, 0, zMovement);
        transform.Translate(movingDirection  * speed * Time.deltaTime);
    }
}
