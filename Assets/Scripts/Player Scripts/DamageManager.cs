using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float damagePoints;
    [SerializeField] private float knockbackForce = 15f;
    [HideInInspector] public PlayerManager player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.isExposed == true)
            {
                player.healthPoints -= damagePoints * 2;
            }
            else
            {
                player.healthPoints -= damagePoints;
            }

            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 knockbackDirection = collision.transform.position - transform.position;
                knockbackDirection.y = 0;
                knockbackDirection.Normalize();
                player.GetComponent<PlayerMovement>().ApplyKnockback(knockbackDirection * knockbackForce);
            }
        }
    }
}