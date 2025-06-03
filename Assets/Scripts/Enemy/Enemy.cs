using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 30f;
    [SerializeField] private float _damage = 10f;
    private ZombieEnemyAnimation _zombieEnemyAnimation;
    
    public void Start()
    {
        _zombieEnemyAnimation = GetComponentInChildren<ZombieEnemyAnimation>();
    }

    public void TakeDamage(float damage)
    {
        if (_zombieEnemyAnimation != null)
        {
            _zombieEnemyAnimation.HurtAnimation(); 
        }
        _health -= damage;
        if (_health <= 0) Destroy(gameObject);
    }


    private void OnCollisionStay2D(Collision2D collision)
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
