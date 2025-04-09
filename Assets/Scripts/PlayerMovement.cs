using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador. Puede ajustarse desde el Inspector.
    [SerializeField] private float speed = 5f;

    // Almacena la direcci�n del movimiento del jugador.
    private Vector2 _movement;

    // Referencia al componente Rigidbody2D para aplicar f�sica al jugador.
    private Rigidbody2D _rb;

    // M�todo llamado al inicializar el objeto. Se ejecuta antes de Start.
    private void Awake()
    {
        // Obtiene el componente Rigidbody2D asociado al GameObject.
        _rb = GetComponent<Rigidbody2D>();
    }

    // M�todo llamado en cada frame del juego.
    private void Update()
    {
        // Obtiene la direcci�n de movimiento desde InputManager.
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        // Normaliza el vector de movimiento para que su magnitud sea 1,
        // evitando que el jugador se mueva m�s r�pido en diagonales.
        _movement.Normalize();

        // Aplica la direcci�n y velocidad al Rigidbody2D para mover al jugador.
        // Se utiliza linearVelocity para establecer la velocidad directamente.
        _rb.linearVelocity = _movement * speed;
    }
}
