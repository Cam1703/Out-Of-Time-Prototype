using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;

    // Referencias al animador
    private const string _horizontal = "Horizontal"; // Nombre del par�metro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del par�metro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del par�metro de �ltima direcci�n horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del par�metro de �ltima direcci�n vertical en el Animator.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkAnimation(Vector2 movement)
    {
        // Actualiza los par�metros del Animator para controlar las animaciones del jugador.
        // Se asignan los valores de movimiento horizontal y vertical al Animator.
        _animator.SetFloat(_horizontal, movement.x);
        _animator.SetFloat(_vertical, movement.y);

        // Si el jugador se est� moviendo, actualiza la �ltima direcci�n de movimiento.
        if (movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, movement.x);
            _animator.SetFloat(_lastVertical, movement.y);
        }
    }

    public void AttackAnimation()
    {
        // Activa la animaci�n de ataque en el Animator.
    }
}
