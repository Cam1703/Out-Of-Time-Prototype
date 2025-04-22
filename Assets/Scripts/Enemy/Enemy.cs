using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 30f;
    [SerializeField] private float _damage = 10f;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0) Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificar si el jugador tiene un componente de salud
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Aplicar daño al jugador
                playerHealth.TakeDamage(_damage);
            }

        }
    }
}
