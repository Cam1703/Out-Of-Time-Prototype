using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador. Puede ajustarse desde el Inspector.
    [SerializeField] private float speed = 5f;

    // Almacena la dirección del movimiento del jugador.
    private Vector2 _movement;

    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;
    // Referencia al componente Rigidbody2D para aplicar física al jugador.
    private Rigidbody2D _rb;

    private const string _horizontal = "Horizontal"; // Nombre del parámetro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del parámetro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del parámetro de última dirección horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del parámetro de última dirección vertical en el Animator.

    // Método llamado al inicializar el objeto. Se ejecuta antes de Start.
    private void Awake()
    {
        // Obtiene el componente Rigidbody2D asociado al GameObject.
        _rb = GetComponent<Rigidbody2D>();

        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponentInChildren<Animator>();
    }

    // Método llamado en cada frame del juego.
    private void Update()
    {
        // Obtiene la dirección de movimiento desde InputManager.
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        // Aplica la dirección y velocidad al Rigidbody2D para mover al jugador.
        // Se utiliza linearVelocity para establecer la velocidad directamente.
        _rb.linearVelocity = _movement * speed;

        // Actualiza los parámetros del Animator para controlar las animaciones del jugador.
        // Se asignan los valores de movimiento horizontal y vertical al Animator.
        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        // Si el jugador se está moviendo, actualiza la última dirección de movimiento.
        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }
}
