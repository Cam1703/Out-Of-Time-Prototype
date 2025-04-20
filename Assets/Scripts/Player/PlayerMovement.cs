using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del jugador. Puede ajustarse desde el Inspector.
    [SerializeField] private float speed = 5f;

    // Dirección actual y última dirección de movimiento del jugador.
    private Vector2 _movement;
    private Vector2 _lastMovement;

    // Referencia al Transform del objeto Aim, que indica hacia dónde apunta el jugador.
    [SerializeField] private Transform _aim;

    // Referencia al componente Rigidbody2D, usado para aplicar movimiento físico al jugador.
    private Rigidbody2D _rb;

    // Referencia al controlador de animaciones del jugador.
    private PlayerAnimation _playerAnimation;

    // Método llamado al inicializar el objeto. Se ejecuta antes de Start.
    private void Awake()
    {
        // Obtiene el componente Rigidbody2D asociado al GameObject.
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    // Método llamado en cada frame del juego.
    private void Update()
    {
        MovePlayer(); // Gestiona el movimiento del jugador
        _playerAnimation.WalkAnimation(_movement); // Actualiza la animación de caminar
        RotateAim(); // Rota el Aim en función de la dirección
    }

    // Obtiene la entrada del jugador y aplica movimiento al Rigidbody2D.
    private void MovePlayer()
    {
        // Obtiene la dirección de movimiento desde InputManager.
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        // Aplica la dirección y velocidad al Rigidbody2D para mover al jugador.
        // Se utiliza linearVelocity para establecer la velocidad directamente.
        _rb.linearVelocity = _movement * speed;

        if(_movement != Vector2.zero)
        {
            _lastMovement = _movement;
        }
    }

    // Rota el objeto Aim para que apunte en la dirección del último movimiento del jugador.
    private void RotateAim()
    {
        Vector3 direction = Vector3.left * _lastMovement.x + Vector3.down * _lastMovement.y;

        _aim.rotation = Quaternion.LookRotation(Vector3.forward,direction);
    }
}
