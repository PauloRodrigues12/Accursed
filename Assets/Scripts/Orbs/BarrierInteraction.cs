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
                    Debug.Log("Desativa as putas");
                    Collider PIcollider = barriers[0].GetComponent<BoxCollider>();
                    PIcollider.enabled = false;
                    Collider PIcollider2 = barriers[1].GetComponent<BoxCollider>();
                    PIcollider2.enabled = false;
                    barriers[0].SetActive(true);
                    barriers[1].SetActive(true);

                    break;
                case "Stagnating Faculty":
                    Debug.Log("Deactivated Barriers");
                    Collider SFcollider = barriers[2].GetComponent<Collider>();
                    SFcollider.enabled = false;
                    Collider SFcollider2 = barriers[3].GetComponent<Collider>();
                    SFcollider2.enabled = false;
                    Collider SFcollider4 = barriers[9].GetComponent<Collider>();
                    SFcollider4.enabled = false;
                    barriers[2].SetActive(true);
                    barriers[3].SetActive(true);
                    barriers[9].SetActive(true);

                    break;
                case "Fragile Strenght":
                    Debug.Log("Deactivated Barriers");
                    Collider FScollider = barriers[4].GetComponent<Collider>();
                    FScollider.enabled = false;
                    Collider FScollider2 = barriers[5].GetComponent<Collider>();
                    FScollider2.enabled = false;
                    barriers[4].SetActive(true);
                    barriers[5].SetActive(true);

                    break;
                case "Sheltered Blindness":
                    Debug.Log("Deactivated Barriers");
                    Collider SBcollider = barriers[7].GetComponent<Collider>();
                    SBcollider.enabled = false;
                    barriers[7].SetActive(true);

                    break;
                case "Fools Sight":
                    Debug.Log("Deactivated Barriers");
                    Collider FoScollider = barriers[8].GetComponent<Collider>();
                    FoScollider.enabled = false;
                    Collider SBcollider2 = barriers[6].GetComponent<Collider>();
                    SBcollider2.enabled = false;
                    barriers[8].SetActive(true);
                    barriers[6].SetActive(true);
                    

                    break;
            }
        
    }

    public void ActivateBarriers()
    {
        Debug.Log("Ativa as putas");
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
