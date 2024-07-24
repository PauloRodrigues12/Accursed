using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    private Quaternion projectileDirection;
    public GameObject projectile;
    public float shootingCooldown;
    private float shootingTimer;
    void Start()
    {
        healthPoints = 10;
        shootingTimer = shootingCooldown;

        projectileDirection = transform.rotation;

        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), projectileDirection);
    }
    void Update()
    {
        shootingTimer -= Time.deltaTime;

        if (shootingTimer <= 0)
        {
            Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), projectileDirection);
            shootingTimer = shootingCooldown;
        }
    }
}