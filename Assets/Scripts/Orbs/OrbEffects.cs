using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbEffects : MonoBehaviour
{
    [Header("Pink Orb Effects")]
    [SerializeField] private float regenerationRate = 1.0f;
    private float timeSinceLastRegen = 0.0f;

    [Header("Blue Orb Effects")]
    public GameObject blueProjectile;
    [SerializeField] private Transform holster;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float timeBeforeShooting;
    private float timeSinceLastShot = 0.0f;

    [Header("Yellow Orb Effects")]
    [SerializeField] private float attackSpeed = 2.0f;
    [SerializeField] private float damageTaken;
    private float timeSinceLastAttack = 0.0f;

    [Header("Purple Orb Effects")]
    [SerializeField] private GameObject globalVolume;

    [Header("Green Orb Effects")]
    [SerializeField] private float alpha = 0.0f;
    [SerializeField] private Material invisibleWallMat;

    public OrbPickUp orbPickedUp;
    private PlayerMovement m_player;

    private void Start()
    { 
        m_player = FindFirstObjectByType<PlayerMovement>();
    }
    private void Update()
    {
        if (orbPickedUp.currentlyHeldOrb != null)
        {
            switch (orbPickedUp.currentlyHeldOrb.orbType.color)
            {
                case "Pink":

                    GetPinkBuff();

                    break;
                case "Blue":

                    GetBlueBuff();

                    break;
                case "Yellow":

                    GetYellowBuff();

                    break;
                case "Purple":

                    GetPurpleBuff();

                    break;
                case "Green":

                    GetGreenBuff();

                    break;
            }
        }
    }

    private void GetPinkBuff()
    {
        timeSinceLastRegen += Time.deltaTime;

        if (timeSinceLastRegen > regenerationRate)
        {
            if (m_player.healthPoints < m_player.maxHealthPoints)
            {
                m_player.healthPoints++;
                m_player.maxHealthPoints--;
            }

            timeSinceLastRegen = 0.0f;
        }
    }

    private void GetBlueBuff()
    {
        m_player.speed = 5f;
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= timeBeforeShooting)
        {
            GameObject projectile = Instantiate(blueProjectile, holster.position, holster.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = holster.forward * projectileSpeed;
            }
            timeSinceLastShot = 0.0f;
        }
    }

    private void GetYellowBuff()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (timeSinceLastAttack >= attackSpeed)
        {
            // Depois meter a logica do Player a atacar aqui
            Debug.Log("Ataquei");

            timeSinceLastAttack = 0.0f;
        }
    }

    private void GetPurpleBuff()
    {
        globalVolume.SetActive(true);
        //Set UnActive aos Projeteis Roxos aqui
    }

    private void GetGreenBuff()
    {
        
    }

    public void UndoAllBuffs()
    {

    }
}
