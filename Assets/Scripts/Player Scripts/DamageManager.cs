using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private float knockbackForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // depois chamar um script que contenha a variavel da vida do Player e meter aqui a decrementacao pelo dano

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 knockbackDirection = collision.transform.position - transform.position;
            knockbackDirection.Normalize();

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        }
    }
}
