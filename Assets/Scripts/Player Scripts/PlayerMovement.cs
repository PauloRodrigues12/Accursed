using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gameplay Variables")]
    public float speed;
    public float lookAtSpeed;
    public Transform playerModel;
    
    [Header("Attacking Variables")]
    public GameObject attackArea;
    public GameObject vfxArea;

    public float attackingCooldown;
    private float attackingTimer;
    private bool isAttacking;
    private bool attackCooldown;

    [Header("Animation Variables")]
    public Animator animator;
    [HideInInspector] public OrbPickUp orbPickUp;

    void Start ()
    {
        orbPickUp = GetComponent<OrbPickUp>();
        attackingTimer = attackingCooldown;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && attackCooldown == false && orbPickUp.isHoldingOrb == false)
            isAttacking = true;

        if (isAttacking == true)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(AnimDuration(.1f));
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

        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalInput));
        animator.SetFloat("VerticalSpeed", Mathf.Abs(verticalInput));
        animator.SetBool("HoldingOrb", orbPickUp.isHoldingOrb);

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

        yield return new WaitForSeconds(intervalTime);

        attackArea.SetActive(true);
        vfxArea.SetActive(true);

        yield return new WaitForSeconds(intervalTime);

        animator.ResetTrigger("Attack");
        attackArea.SetActive(false);

        yield return new WaitForSeconds(.5f);

        vfxArea.SetActive(false);
    }
}