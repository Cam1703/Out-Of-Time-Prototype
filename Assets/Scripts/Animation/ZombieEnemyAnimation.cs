using UnityEngine;

public class ZombieEnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void HurtAnimation()
    {
        // Hace un parpadeo del sprite del jugador al recibir daño.
        _sprite.color = new Color(1f, 0.5f, 0.5f, 1f); // Cambia el color del sprite a rojo claro.
        Invoke("ResetSpriteColor", 0.1f); // Llama a ResetSpriteColor después de 0.1 segundos.
    }


    public void MaleeAttackAnimation()
    {
        // Activa la animación de ataque en el Animator.
    }

    private void ResetSpriteColor()
    {
        // Restaura el color original del sprite del jugador.
        _sprite.color = Color.white; // Cambia el color del sprite a blanco.
    }
}
