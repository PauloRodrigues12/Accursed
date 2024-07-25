using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Vector3 movingVector;
    private Vector3 destinationA;
    private Vector3 destinationB;
    private Quaternion playerRotationA;
    private Quaternion playerRotationB;
    public float moveSpeed;
    private bool turned;
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        destinationA = transform.position;
        destinationB = transform.position + movingVector;

        playerRotationA = transform.rotation;
        playerRotationB = transform.rotation * Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        if (animator.GetBool("isDead") == true)
        {
            transform.position = transform.position;
        }
        else
        {
            if (turned != true)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationB, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationA, moveSpeed * Time.deltaTime);
            }

            if (transform.position == destinationA && turned == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, playerRotationA, .05f);

                StartCoroutine(turnAround(1f, false));
            }
            else if (transform.position == destinationB && turned == false)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, playerRotationB, .05f);

                StartCoroutine(turnAround(1f, true));
            }
        }
    }

    IEnumerator turnAround(float intervalTime, bool turnState)
    {
        yield return new WaitForSeconds(intervalTime);

        turned = turnState;
    }
}