using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierInteraction : MonoBehaviour
{
    [SerializeField] private GameObject[] barriers;

    [SerializeField] private OrbData[] orbType;

    public OrbPickUp orbPicked;

    [Header("Socket Stuff")]
    [SerializeField] private float putInRange = 1f;

    public void DeactivateBarriers()
    {
        switch (orbPicked.currentlyHeldOrb.orbType.orbName)
        {
            case "Pseudo Immortality":

                Collider PIcollider = barriers[0].GetComponent<Collider>();
                PIcollider.enabled = false;
                Collider PIcollider2 = barriers[1].GetComponent<Collider>();
                PIcollider2.enabled = false;
                barriers[0].SetActive(true);
                barriers[1].SetActive(true);

                break;
            case "Stagnating Faculty":

                Collider SFcollider = barriers[2].GetComponent<Collider>();
                SFcollider.enabled = false;
                Collider SFcollider2 = barriers[3].GetComponent<Collider>();
                SFcollider2.enabled = false;
                barriers[2].SetActive(true);
                barriers[3].SetActive(true);

                break;
            case "Fragile Strenght":

                Collider FScollider = barriers[4].GetComponent<Collider>();
                FScollider.enabled = false;
                Collider FScollider2 = barriers[5].GetComponent<Collider>();
                FScollider2.enabled = false;
                barriers[4].SetActive(true);
                barriers[5].SetActive(true);

                break;
            case "Sheltered Blindness":

                Collider SBcollider = barriers[6].GetComponent<Collider>();
                SBcollider.enabled = false;
                Collider SBcollider2 = barriers[7].GetComponent<Collider>();
                SBcollider2.enabled = false;
                barriers[6].SetActive(true);
                barriers[7].SetActive(true);

                break;
            case "Fools Sight":

                Collider FoScollider = barriers[8].GetComponent<Collider>();
                FoScollider.enabled = false;
                barriers[8].SetActive(true);

                break;
        }
    }

    public void ActivateBarriers()
    {
        for (int i = 0; i < barriers.Length; i++)
        {
            Collider colliders = barriers[i].GetComponent<Collider>();
            colliders.enabled = true;
        }
    }

    public void DisableBarriers(int socketIndex)
    {
        barriers[socketIndex].SetActive(false);
    }
    public void EnableBarriers(int socketIndex)
    {
        barriers[socketIndex].SetActive(true);
    }
}
