using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbData orbType;

     private BarrierInteraction barrier;

     private OrbEffects orbEffects;

    private void Start()
    {
        barrier = FindFirstObjectByType<BarrierInteraction>();
        orbEffects = FindFirstObjectByType<OrbEffects>();
    }
    public void OnPickUp(Transform holster)
    {
        Debug.Log("Picked up " + orbType.orbName);
        transform.SetParent(holster);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Collider orbCollider = GetComponent<Collider>();
        orbCollider.enabled = false;
        
        barrier.DeactivateBarriers();
        Debug.Log("Disabled the collider");
    }

    public void OnSwap(Vector3 swapPosition)
    {
        Debug.Log("Swapped for " + orbType.orbName);
        transform.SetParent(null);
        transform.position = swapPosition;
        GetComponent<Collider>().enabled = true;
        barrier.ActivateBarriers();
    }

    public void OnDrop(Vector3 dropPosition)
    {
        Debug.Log("Dropped " + orbType.orbName);
        transform.SetParent(null);
        transform.position = new Vector3(dropPosition.x, 0.5f, dropPosition.z);
        GetComponent<Collider>().enabled = true;
        barrier.ActivateBarriers();
        orbEffects.UndoAllBuffs();
    }

    public void OnSocket(Vector3 socketPosition, int socketIndex)
    {
        transform.SetParent(null);
        transform.position = new Vector3(socketPosition.x, 0.5f, socketPosition.z);
        GetComponent<Collider>().enabled = true;
        barrier.ActivateBarriers();
        barrier.DisableBarriers(socketIndex);
        orbEffects.UndoAllBuffs();
    }
}
