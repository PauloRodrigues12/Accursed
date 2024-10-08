using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPickUp : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 2f;
    [SerializeField] private float socketPlaceRange = 1f;
    public LayerMask pickUpLayer;
    public LayerMask socketLayer;
    public Transform holster;

    public bool isHoldingOrb = false;

    public Orb currentlyHeldOrb;

    private void LateUpdate()
    {
        if (isHoldingOrb && currentlyHeldOrb != null)
        {
            TryPlacingOrbOnSocket();
        }
        else
        {
            TryPickUp();
        }
    }

    private void TryPickUp()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickUpRange, pickUpLayer);
        bool canPickUpOrb = false;

        foreach (var hitCollider in hitColliders)
        {
            Orb pickableOrb = hitCollider.GetComponent<Orb>();
            if (pickableOrb != null)
            {
                canPickUpOrb = true;
                Debug.Log("I can pick up this orb");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Vector3 originalPosition = pickableOrb.transform.position;
                    if (currentlyHeldOrb != null)
                    {
                        currentlyHeldOrb.OnSwap(originalPosition);
                    }
                    currentlyHeldOrb = pickableOrb;
                    currentlyHeldOrb.OnPickUp(holster);
                    Debug.Log("I picked the orb in code A");
                    isHoldingOrb = true;
                    break;
                }
            }
        }

        if (isHoldingOrb && !canPickUpOrb && Input.GetKeyDown(KeyCode.F))
        {
            currentlyHeldOrb.OnDrop(currentlyHeldOrb.transform.position);
            currentlyHeldOrb = null;
            isHoldingOrb = false;
        }
    }

    private void TryPlacingOrbOnSocket()
    {
        Collider[] socketHitColliders = Physics.OverlapSphere(transform.position, socketPlaceRange, socketLayer);

        foreach (var socketHitCollider in socketHitColliders)
        {
            Socket socket = socketHitCollider.GetComponent<Socket>();
            if (socket != null)
            {
                if (socket.orbColor == currentlyHeldOrb.orbType.color)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        currentlyHeldOrb.OnSocket(socket.transform.position, socket.socketIndex); 
                        currentlyHeldOrb = null;
                        isHoldingOrb = false;
                        return;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            currentlyHeldOrb.OnDrop(currentlyHeldOrb.transform.position);
            currentlyHeldOrb = null;
            isHoldingOrb = false;
        }
    }
}
