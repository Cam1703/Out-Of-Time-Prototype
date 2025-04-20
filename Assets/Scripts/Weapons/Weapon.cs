using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name); //TO-DO: Fix bug: El collider del enemigo no se detecta al atacar repetidas veces sin moverse
        //Verificar si se ha chocado contra un enemigo
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
