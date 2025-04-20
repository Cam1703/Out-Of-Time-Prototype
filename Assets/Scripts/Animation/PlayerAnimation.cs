using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;

    // Referencias al animador
    private const string _horizontal = "Horizontal"; // Nombre del parámetro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del parámetro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del parámetro de última dirección horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del parámetro de última dirección vertical en el Animator.

    void Start()
    {
        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponent<Animator>();
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

    public void MaleeAttackAnimation()
    {
        // Activa la animación de ataque en el Animator.
    }
}
