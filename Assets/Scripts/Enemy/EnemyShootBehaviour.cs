using System.Collections;
using UnityEngine;

public class EnemyShootBehaviour : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _reloadTime = 1f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private ShootDirection _shootDirection = ShootDirection.Up;

    private FollowPlayerBehaviour _followPlayerBehaviour;
    private float _nextShootTime = 0f;
    private GameObject _player;
    private bool _isChasing = false;

    private void Awake()
    {
        if (!TryGetComponent<FollowPlayerBehaviour>(out _followPlayerBehaviour))
        {
            Debug.Log("FollowPlayerBehaviour component is not attached to the GameObject.");
        }
    }

    private void Start()
    {
        if (_bullet == null)
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }

        if (_shootPoint == null)
        {
            Debug.LogError("ShootPoint Transform is not assigned.");
        }

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_followPlayerBehaviour != null)
        {
            _isChasing = _followPlayerBehaviour.IsChasing;
        }

        if (_player == null || _shootPoint == null) return;

        Vector2 distanceToPlayer = _player.transform.position - transform.position;

        // Solo dispara si el jugador está en rango y está siendo perseguido (o no hay FollowPlayerBehaviour)
        if (distanceToPlayer.magnitude <= _range && (_followPlayerBehaviour == null || _isChasing))
        {
            StartCoroutine(ShootCoroutine());
        }

        Debug.DrawLine(_shootPoint.position, _shootPoint.position + (Vector3)GetDirection() * _range, Color.red);
    }


    private IEnumerator ShootCoroutine()
    {
        if (Time.time >= _nextShootTime)
        {
            _nextShootTime = Time.time + _reloadTime;

            GameObject bulletInstance = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = GetDirection();
                rb.AddForce(direction * 10f, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(_reloadTime);
        }
        else
        {
            yield return null; // Espera al siguiente frame si no está listo
        }
    }

    private Vector2 GetDirection()
    {
        switch (_shootDirection)
        {
            case ShootDirection.Up:
                return Vector2.up;
            case ShootDirection.Down:
                return Vector2.down;
            case ShootDirection.Left:
                return Vector2.left;
            case ShootDirection.Right:
                return Vector2.right;
            case ShootDirection.Player:
                if (_player != null)
                {
                    return (_player.transform.position - _shootPoint.position).normalized;
                }
                break;
        }

        return Vector2.zero;
    }
}

public enum ShootDirection
{
    Left,
    Right,
    Up,
    Down,
    Player
}
