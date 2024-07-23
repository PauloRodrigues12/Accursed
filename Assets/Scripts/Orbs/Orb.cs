using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbData orbType;

    public void OnPickUp(Transform holster)
    {
        Debug.Log("Picked up " + orbType.orbName);
        transform.SetParent(holster);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GetComponent<Collider>().enabled = false;
    }

    public void OnSwap(Vector3 swapPosition)
    {
        Debug.Log("Swapped for " + orbType.orbName);
        transform.SetParent(null);
        transform.position = swapPosition;
        GetComponent<Collider>().enabled = true; 
    }

    public void OnDrop(Vector3 dropPosition)
    {
        Debug.Log("Dropped " + orbType.orbName);
        transform.SetParent(null);
        transform.position = new Vector3(dropPosition.x, GetGroundYPosition(dropPosition), dropPosition.z);
        GetComponent<Collider>().enabled = true;
    }

    private float GetGroundYPosition(Vector3 position)
    {
        return 0.25f;
    }
}
