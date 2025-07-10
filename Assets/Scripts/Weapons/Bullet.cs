using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");

        // Ignorar enemigos (por tag) pero solo si el collider es un CircleCollider2D
        if (collision.gameObject.CompareTag("Enemy") && collision is CircleCollider2D)
        {
            return; // ignorar colisión
        }

        if (!isPlayer)
        {
            Destroy(gameObject);
        }
    }
}
