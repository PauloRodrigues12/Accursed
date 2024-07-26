using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbEffects : MonoBehaviour
{
    [Header("Pink Orb Effects")]
    [SerializeField] private float regenerationRate = 1.0f;
    private float timeSinceLastRegen = 0.0f;
    private bool isWithPinkBuffs = false;

    [Header("Blue Orb Effects")]
    public GameObject blueProjectile;
    [SerializeField] private Transform holster;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float timeBeforeShooting;
    private float timeSinceLastShot = 0.0f;
    private bool isWithBlueBuffs = false;

    [Header("Yellow Orb Effects")]
    [SerializeField] private float attackSpeed = 2.0f;
    [SerializeField] private float damageTakenIncrease;
    private float timeSinceLastAttack = 0.0f;
    private bool isWithYellowBuffs = false;

    [Header("Purple Orb Effects")]
    [SerializeField] private GameObject globalVolume;
    //Criar Variavel dos projeteis Roxos
    private bool isWithPurpleBuffs = false;

    [Header("Green Orb Effects")]
    [SerializeField] private float alpha = 0.0f;
    [SerializeField] private float initialAlpha = 0.4f;
    [SerializeField] private Material[] invisibleMats;
    private bool isWithGreenBuffs = false;

    public OrbPickUp orbPickedUp;

    private PlayerMovement m_player;
    private PlayerManager hp_player;

    private void Start()
    { 
        m_player = FindFirstObjectByType<PlayerMovement>();
        hp_player = FindFirstObjectByType<PlayerManager>();
    }
    private void Update()
    {
        if (orbPickedUp.currentlyHeldOrb != null)
        {
            switch (orbPickedUp.currentlyHeldOrb.orbType.color)
            {
                case "Pink":

                    isWithPinkBuffs = true;
                    GetPinkBuff();

                    break;
                case "Blue":

                    isWithBlueBuffs = true;
                    GetBlueBuff();

                    break;
                case "Yellow":

                    isWithYellowBuffs = true;
                    GetYellowBuff();

                    break;
                case "Purple":

                    isWithPurpleBuffs = true;
                    GetPurpleBuff();

                    break;
                case "Green":

                    isWithGreenBuffs = true;
                    GetGreenBuff();

                    break;
            }
        }
    }

    private void GetPinkBuff()
    {
        if (isWithPinkBuffs)
        {
            timeSinceLastRegen += Time.deltaTime;

            if (timeSinceLastRegen > regenerationRate)
            {
                if (hp_player.healthPoints < hp_player.maxHealthPoints)
                {
                    hp_player.healthPoints++;
                    hp_player.maxHealthPoints--;
                }

                timeSinceLastRegen = 0.0f;
            }
        }    
    }

    private void GetBlueBuff()
    {
        if (isWithBlueBuffs)
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
    }

    private void GetYellowBuff()
    {
        if (isWithYellowBuffs)
        {
            //Meter o Player a levar Double Damage
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= attackSpeed)
            {
                // Depois meter a logica do Player a atacar aqui
                Debug.Log("Ataquei");

                timeSinceLastAttack = 0.0f;
            }
        }
        
    }

    private void GetPurpleBuff()
    {
            globalVolume.SetActive(true);
            //Set UnActive aos Projeteis Roxos aqui      
    }

    private void GetGreenBuff()
    {
        if (isWithGreenBuffs)
        {
            for (int i = 0; i < invisibleMats.Length; i++)
            {
                Color color = invisibleMats[i].color;
                color.a = alpha;
                invisibleMats[i].color = color;
            }
        }
    }

    public void UndoAllBuffs()
    {
        m_player.speed = 10f;
        globalVolume.SetActive(false);
        for (int i = 0; i < invisibleMats.Length; i++)
        {
            Color color = invisibleMats[i].color;
            color.a = initialAlpha;
            invisibleMats[i].color = color;
        }
        //Depois tirar as booleanas desnecessarias
        isWithPinkBuffs = false;
        isWithBlueBuffs = false;
        isWithYellowBuffs = false;
        isWithPurpleBuffs = false;
        isWithGreenBuffs = false;
    } 
}
