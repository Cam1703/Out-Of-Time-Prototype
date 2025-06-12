using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _lifetime = 5f;
    private PlayerHealth _playerHealth;
    void Start()
    {
        _playerHealth = FindFirstObjectByType<PlayerHealth>();
        Destroy(gameObject, _lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            // Si colisiona con otro enemigo, no hacer nada
            return;
        }

        if (collision.CompareTag("Player"))
        {
            // Aquí puedes aplicar daño al jugador
            if (_playerHealth != null)
            {
                _playerHealth.TakeDamage(10); 
            }
            Destroy(gameObject);
        }
        else if (!collision.isTrigger)
        {
            Destroy(gameObject); // Destruir si colisiona con algo sólido
        }
    }

}
