using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject vfxArea;
    public float attackingCooldown;
    private float attackingTimer;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        attackingTimer = attackingCooldown;
    }

    void Update()
    {
        if (animator.GetBool("isDead") == false)
        {
            attackingTimer -= Time.deltaTime;
        }

        if (attackingTimer <= 0)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(AnimDuration(.1f));
            attackingTimer = attackingCooldown;
        }
    }
    IEnumerator AnimDuration(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);

        attackArea.SetActive(true);
        vfxArea.SetActive(true);

        yield return new WaitForSeconds(.4f);
        
        animator.ResetTrigger("Attack");
        attackArea.SetActive(false);

        yield return new WaitForSeconds(.1f);

        vfxArea.SetActive(false);
    }
}