using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public GameObject attackArea;
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
        attackingTimer -= Time.deltaTime;

        if (attackingTimer <= 0)
        {
            attackArea.SetActive(true);
            animator.SetTrigger("Attack");
            StartCoroutine(AnimDuration(.5f));
            attackingTimer = attackingCooldown;
        }
    }
    IEnumerator AnimDuration(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        
        animator.ResetTrigger("Attack");
        attackArea.SetActive(false);
    }
}