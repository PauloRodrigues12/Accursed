using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public float attackPoints;

    [HideInInspector] public EnemyManager enemy;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Enemy") || collider.gameObject.CompareTag("MeleeEnemy"))
        {
            enemy = collider.gameObject.GetComponent<EnemyManager>();
            enemy.healthPoints -= attackPoints;
        }

        if(collider.gameObject.CompareTag("ArmouredEnemy"))
        {
            enemy = collider.gameObject.GetComponent<EnemyManager>();
            
            enemy.shieldVFX.SetActive(true);

        }
    }   
}