using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float healthPoints;
    private Animator animator;
    private Collider collider;
    public GameObject shieldVFX;

    void Start()
    {
        animator = GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        if (healthPoints <= 0)
        {
            animator.SetBool("isDead", true);
            collider.enabled = false;
            StartCoroutine(endAnim(3f));
        }

        if (shieldVFX != null && shieldVFX.activeSelf == true)
            StartCoroutine(endVFX(1f));
    }

    IEnumerator endAnim(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);
        Destroy(gameObject);
    }

    IEnumerator endVFX(float intervalTime)
    {
        yield return new WaitForSeconds(intervalTime);

        shieldVFX.SetActive(false);
    }
}
