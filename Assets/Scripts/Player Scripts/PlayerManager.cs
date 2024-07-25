using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("Player Health Variables")]
    public float healthPoints;
    public float maxHealthPoints;
    public bool isExposed;
    [Header("Animation Variables")]
    public Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }

        if (healthPoints <= 0)
        {
            animator.SetBool("isDead", true);
            playerMovement.enabled = false;
            StartCoroutine(restartGame(3f));
        }
    }

    IEnumerator restartGame(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        
        SceneManager.LoadScene("BaseMap");
    }
}
