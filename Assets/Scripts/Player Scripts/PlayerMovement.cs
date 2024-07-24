using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float lookAtSpeed;
    public Transform playerModel;
    
    [Header("Attacking Variables")]
    public GameObject attackArea;
    public float attackingCooldown;
    private float attackingTimer;
    private bool isAttacking;
    private bool attackCooldown;

    void Start ()
    {
        attackingTimer = attackingCooldown;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && attackCooldown == false)
            isAttacking = true;

        if (isAttacking == true)
        {
            attackArea.SetActive(true);
            StartCoroutine(AnimDuration(.5f));
        }

        if(attackCooldown == true)
            attackingTimer -= Time.deltaTime;

        if (attackingTimer < 0)
        {
            attackCooldown = false;
            attackingTimer = attackingCooldown;
        }
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

    IEnumerator AnimDuration(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        isAttacking = false;
        attackCooldown = true;
        attackArea.SetActive(false);
    }
}