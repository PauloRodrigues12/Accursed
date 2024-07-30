using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gameplay Variables")]
    public float speed;
    public float lookAtSpeed;
    public Transform playerModel;
    private Rigidbody rb;

    [Header("Knockback Variables")]
    private bool isKnockedBack;
    private Vector3 knockbackVelocity;
    public float knockbackDecayRate;

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
        rb = GetComponent<Rigidbody>();
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

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalInput));
        animator.SetFloat("VerticalSpeed", Mathf.Abs(verticalInput));
        animator.SetBool("HoldingOrb", orbPickUp.isHoldingOrb);
        
        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, verticalInput).normalized * speed;

        if (rb.velocity != Vector3.zero)
        {
            Quaternion lookAtRotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, lookAtRotation, lookAtSpeed * Time.deltaTime);
        }

        /*
        var direction = transform.forward * verticalInput + transform.right * horizontalInput;
        direction.Normalize();
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion lookAtRotation = Quaternion.LookRotation(direction, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, lookAtRotation, lookAtSpeed * Time.deltaTime);
        }
        */
        Vector3 inputVelocity = new Vector3(horizontalInput, 0, verticalInput).normalized * speed;
        if (isKnockedBack)
        {
            rb.velocity = inputVelocity + knockbackVelocity;
            knockbackVelocity = Vector3.Lerp(knockbackVelocity, Vector3.zero, knockbackDecayRate * Time.deltaTime);
            if (knockbackVelocity.magnitude < 0.1f)
            {
                isKnockedBack = false;
            }
        }
        else
        {
            rb.velocity = inputVelocity;
        }

    }

    public void ApplyKnockback(Vector3 force)
    {
        knockbackVelocity = force;
        isKnockedBack = true;
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