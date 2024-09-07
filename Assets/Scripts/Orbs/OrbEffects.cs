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
    [SerializeField] private Transform playerModel;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float timeBeforeShooting;
    private float timeSinceLastShot = 0.0f;
    private bool isWithBlueBuffs = false;

    [Header("Yellow Orb Effects")]
    [SerializeField] private float attackSpeed = 2.0f;
    public GameObject yellowAttackArea;
    public GameObject yellowVfxArea;
    private float timeSinceLastAttack = 0.0f;
    private bool isWithYellowBuffs = false;

    [Header("Purple Orb Effects")]
    [SerializeField] private GameObject oblivionCircle;
    public List<GameObject> purpleEnemies = new List<GameObject>();
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
                Instantiate(blueProjectile, new Vector3(holster.position.x, holster.position.y + 2f, holster.position.z), playerModel.rotation);
                timeSinceLastShot = 0.0f;
            }
        }
    }

    private void GetYellowBuff()
    {
        if (isWithYellowBuffs)
        {
            hp_player.isExposed = true;

            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= attackSpeed)
            {
                yellowAttackArea.SetActive(true);

                StartCoroutine(yellowAnim(.1f));

                timeSinceLastAttack = 0.0f;
            }
        }
        
    }

    private void GetPurpleBuff()
    {
        oblivionCircle.SetActive(true);
        
        for (int i = 0; i < purpleEnemies.Count; i++)
        {
            if (purpleEnemies[i] != null)
            {
                purpleEnemies[i].SetActive(false);
            }
        }
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

            m_player.speed = -10;
            //m_player.playerModel.localScale = new Vector3(1, 1, -1);
        }
    }

    public void UndoAllBuffs()
    {
        m_player.speed = 10f;
        oblivionCircle.SetActive(false);
        
        for (int i = 0; i < invisibleMats.Length; i++)
        {
            Color color = invisibleMats[i].color;
            color.a = initialAlpha;
            invisibleMats[i].color = color;
        }

        for (int i = 0; i < purpleEnemies.Count; i++)
        {
            if (purpleEnemies[i] != null)
            {
                purpleEnemies[i].SetActive(true);
            }
        }

        //Depois tirar as booleanas desnecessarias
        isWithPinkBuffs = false;
        isWithBlueBuffs = false;
        isWithYellowBuffs = false;
        isWithPurpleBuffs = false;
        isWithGreenBuffs = false;

        //Remover o expose effect do player (receber double damage)
        hp_player.isExposed = true;

        //Forçar o speed do jogador ao normal e devolver os controlos normais
        m_player.speed = 10;
        //m_player.playerModel.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator yellowAnim(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);

        yellowVfxArea.SetActive(true);

        yield return new WaitForSeconds(intervalTime);

        yellowAttackArea.SetActive(false);

        yield return new WaitForSeconds(.3f);
        
        yellowVfxArea.SetActive(false);
    }
}