using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float lookAtSpeed;
    public Transform playerModel;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movingDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(movingDirection  * speed * Time.deltaTime, Space.World);

        if (movingDirection != Vector3.zero)
        {
            Quaternion lookAtRotation = Quaternion.LookRotation(movingDirection, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, lookAtRotation, lookAtSpeed * Time.deltaTime);
        }
    }
}