using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Propiedad estática que almacena la dirección del movimiento del jugador.
    // Es accesible desde cualquier otra clase sin necesidad de instanciar InputManager.
    public static Vector2 Movement; 

    // Referencia al componente PlayerInput que gestiona las acciones de entrada.
    private PlayerInput _playerInput;

    // Acción de entrada específica para el movimiento del jugador.
    private InputAction _moveAction;

    // Método llamado al inicializar el objeto. Se ejecuta antes de Start.
    private void Awake()
    {
        // Obtiene el componente PlayerInput asociado al GameObject.
        _playerInput = GetComponent<PlayerInput>();

        // Recupera la acción de entrada llamada "Move" desde el mapa de acciones configurado.
        // Esto permite vincular las entradas del jugador (como teclas o joystick) a la lógica del juego.
        _moveAction = _playerInput.actions["Move"];
    }

    // Método llamado en cada frame del juego.
    private void Update()
    {
        // Lee el valor actual de la acción "Move" como un Vector2 (por ejemplo, (1, 0) para moverse a la derecha).
        // Asigna este valor a la propiedad estática Movement, que puede ser utilizada por otras clases.
        Movement = _moveAction.ReadValue<Vector2>();
    }
}
