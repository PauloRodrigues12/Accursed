using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float damagePoints;
    [SerializeField] private float knockbackForce = 10f;
    [HideInInspector] public PlayerManager player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // depois chamar um script que contenha a variavel da vida do Player e meter aqui a decrementacao pelo dano
            if (player.isExposed == true)
            {
                damagePoints *= 2;
                player.healthPoints -= damagePoints;
            } 
            else
                player.healthPoints -= damagePoints;

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 knockbackDirection = collision.transform.position - transform.position;
            knockbackDirection.Normalize();

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        }
    }
}