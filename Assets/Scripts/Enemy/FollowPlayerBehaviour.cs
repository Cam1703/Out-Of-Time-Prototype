using UnityEngine;

public class FollowPlayerBehaviour : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;
    private bool _isChasing;
    private int _facingDirection = 1; // 1 para derecha, -1 para izquierda
    private Enemy _enemy; // Referencia al script Enemy

    [SerializeField] private float _speed = 2f;

    public bool IsChasing { get => _isChasing; set => _isChasing = value; }

    void Start()
    {
        _enemy = GetComponent<Enemy>(); // Obtiene la referencia al script Enemy
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _isChasing = false; // Inicialmente no persigue al jugador
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isChasing)
        {
            if((_enemy.EnemyState != EnemyState.Attack )) _enemy.ChangeState(EnemyState.Chase); // Cambia el estado del enemigo a Chase
            if (_player.transform.position.x < transform.position.x && _facingDirection == 1)
            {
                Flip(); // Voltea al enemigo si el jugador est�� a la izquierda
            }
            else if (_player.transform.position.x > transform.position.x && _facingDirection == -1)
            {
                Flip(); // Voltea al enemigo si el jugador est�� a la derecha
            }
            Vector2 vector2 = _player.transform.position - transform.position;
            vector2.Normalize();
            _rb.MovePosition((Vector2)transform.position + vector2 * _speed * Time.deltaTime);
        }
        else
        {
            _enemy.ChangeState(EnemyState.Idle); // Cambia el estado del enemigo a Idle
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            // Detiene la persecuci�n al salir del trigger
            _rb.linearVelocity = Vector2.zero; // Detiene el movimiento
            _isChasing = false;
        }
    }

    private void Flip()
    {
        _facingDirection *= -1; // Cambia la direcci�n de la cara
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Invierte la escala en el eje X
        transform.localScale = localScale;
    }
}
