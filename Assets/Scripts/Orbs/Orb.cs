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

    public void OnDrop(Vector3 dropPosition)
    {
        Debug.Log("Dropped " + orbType.orbName);
        transform.SetParent(null);
        transform.position = dropPosition;
        GetComponent<Collider>().enabled = true; 
    }
}
