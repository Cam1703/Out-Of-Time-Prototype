using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;
    private SpriteRenderer _sprite;

    // Referencias al animador
    private const string _horizontal = "Horizontal"; // Nombre del parámetro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del parámetro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del parámetro de última dirección horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del parámetro de última dirección vertical en el Animator.

    void Start()
    {
        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void WalkAnimation(Vector2 movement)
    {
        // Actualiza los parámetros del Animator para controlar las animaciones del jugador.
        // Se asignan los valores de movimiento horizontal y vertical al Animator.
        _animator.SetFloat(_horizontal, movement.x);
        _animator.SetFloat(_vertical, movement.y);

        // Si el jugador se está moviendo, actualiza la última dirección de movimiento.
        if (movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, movement.x);
            _animator.SetFloat(_lastVertical, movement.y);
        }
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
