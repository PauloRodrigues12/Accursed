using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    public GameObject attackArea;
    public float attackingCooldown;
    private float attackingTimer;
    void Start()
    {
        healthPoints = 20;

        attackingTimer = attackingCooldown;
    }

    void Update()
    {
        attackingTimer -= Time.deltaTime;

        if (attackingTimer <= 0)
        {
            attackArea.SetActive(true);
            StartCoroutine(AnimDuration(.5f));
            attackingTimer = attackingCooldown;
        }
    }
    IEnumerator AnimDuration(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        
        attackArea.SetActive(false);
    }
}