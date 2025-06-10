using UnityEngine;

public class FollowPlayerBehaviour : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;
    private bool _isChasing;

    [SerializeField] private float _speed = 2f;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _isChasing = false; // Inicialmente no persigue al jugador
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isChasing)
        {
            Vector2 vector2 = _player.transform.position - transform.position;
            vector2.Normalize();
            _rb.MovePosition((Vector2)transform.position + vector2 * _speed * Time.deltaTime);
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
}
