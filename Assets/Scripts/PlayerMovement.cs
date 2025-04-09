using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador. Puede ajustarse desde el Inspector.
    [SerializeField] private float speed = 5f;

    // Almacena la direcci�n del movimiento del jugador.
    private Vector2 _movement;

    // Referencia al componente Animator para controlar las animaciones del jugador.
    private Animator _animator;
    // Referencia al componente Rigidbody2D para aplicar f�sica al jugador.
    private Rigidbody2D _rb;

    private const string _horizontal = "Horizontal"; // Nombre del par�metro horizontal en el Animator.
    private const string _vertical = "Vertical"; // Nombre del par�metro vertical en el Animator.
    private const string _lastHorizontal = "LastHorizontal"; // Nombre del par�metro de �ltima direcci�n horizontal en el Animator.
    private const string _lastVertical = "LastVertical"; // Nombre del par�metro de �ltima direcci�n vertical en el Animator.

    // M�todo llamado al inicializar el objeto. Se ejecuta antes de Start.
    private void Awake()
    {
        // Obtiene el componente Rigidbody2D asociado al GameObject.
        _rb = GetComponent<Rigidbody2D>();

        // Obtiene el componente Animator asociado al GameObject.
        _animator = GetComponentInChildren<Animator>();
    }

    // M�todo llamado en cada frame del juego.
    private void Update()
    {
        // Obtiene la direcci�n de movimiento desde InputManager.
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        // Aplica la direcci�n y velocidad al Rigidbody2D para mover al jugador.
        // Se utiliza linearVelocity para establecer la velocidad directamente.
        _rb.linearVelocity = _movement * speed;

        // Actualiza los par�metros del Animator para controlar las animaciones del jugador.
        // Se asignan los valores de movimiento horizontal y vertical al Animator.
        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        // Si el jugador se est� moviendo, actualiza la �ltima direcci�n de movimiento.
        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
        }
    }
}
