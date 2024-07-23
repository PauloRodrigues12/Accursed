using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPickUp : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 2f;
    public LayerMask pickUpLayer;
    public Transform holster;

    private Orb currentlyHeldOrb;

    private void LateUpdate()
    {
        TryPickUp();
    }

    private void TryPickUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRange, pickUpLayer);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Im near a pickable object");

            if (Input.GetKeyDown(KeyCode.F))
            {
                Orb pickup = hitCollider.GetComponent<Orb>();
                if (pickup != null)
                {
                    if (currentlyHeldOrb != null)
                    {
                        currentlyHeldOrb.OnDrop(transform.position);
                    }
                    currentlyHeldOrb = pickup;
                    currentlyHeldOrb.OnPickUp(holster);
                    break;
                }
            }
        }
    }
}
