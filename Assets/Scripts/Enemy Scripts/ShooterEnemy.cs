using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    private Quaternion projectileDirection;
    public GameObject projectile;
    public float shootingCooldown;
    private float shootingTimer;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

        shootingTimer = shootingCooldown;

        projectileDirection = transform.rotation;

        animator.SetTrigger("Shoot");
        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), projectileDirection);
        StartCoroutine(resetAnim(.5f));
    }
    void Update()
    {
        if (animator.GetBool("isDead") == false)
        {
            shootingTimer -= Time.deltaTime;
        }

        if (shootingTimer <= 0)
        {
            animator.SetTrigger("Shoot");
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), projectileDirection);

            shootingTimer = shootingCooldown;
        }
    }

    IEnumerator resetAnim(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        
        animator.ResetTrigger("Shoot");
    }
}