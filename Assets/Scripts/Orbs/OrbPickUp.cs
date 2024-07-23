using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPickUp : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 2f;
    public LayerMask pickUpLayer;
    public Transform holster;

    private bool isHoldingOrb = false;

    private Orb currentlyHeldOrb;

    private void LateUpdate()
    {
        TryPickUp();
    }

    private void TryPickUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRange, pickUpLayer);
        bool foundPickableOrb = false;

        foreach (var hitCollider in hitColliders)
        {
            Orb pickableOrb = hitCollider.GetComponent<Orb>();
            if (pickableOrb != null)
            {
                foundPickableOrb = true;
                Debug.Log("I'm near a pickable object");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Vector3 originalPosition = pickableOrb.transform.position;
                    if (currentlyHeldOrb != null)
                    {
                        currentlyHeldOrb.OnSwap(originalPosition); 
                    }
                    currentlyHeldOrb = pickableOrb;
                    currentlyHeldOrb.OnPickUp(holster); 
                    isHoldingOrb = true;
                    break; 
                }
            }
        }

        if (isHoldingOrb && !foundPickableOrb && Input.GetKeyDown(KeyCode.F))
        {
            currentlyHeldOrb.OnDrop(currentlyHeldOrb.transform.position);
            currentlyHeldOrb = null;
            isHoldingOrb = false; 
        }
    }
}
