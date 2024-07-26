using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowAttackManager : MonoBehaviour
{
    public float attackPoints;

    [HideInInspector] public EnemyManager enemy;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("ArmouredEnemy"))
        {
            enemy = collider.gameObject.GetComponent<EnemyManager>();
            enemy.healthPoints -= attackPoints;
        }
    }
}
