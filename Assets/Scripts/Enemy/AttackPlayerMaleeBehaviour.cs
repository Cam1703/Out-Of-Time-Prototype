using UnityEngine;

public class AttackPlayerMaleeBehaviour : MonoBehaviour
{
    private float _maleeAttackRange = 1.5f;
    private GameObject _player;
    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);
        // Dibujar línea del tamaño del rango de ataque (hacia la derecha)
        Debug.DrawLine(transform.position, transform.position + transform.right * _maleeAttackRange, Color.red);
        if (distanceToPlayer <= _maleeAttackRange)
        {
            if (_enemy.EnemyState != EnemyState.Attack)
            {
                _enemy.ChangeState(EnemyState.Attack);
            }
        }
        else
        {
            // Si estaba atacando pero el jugador se alejó, cambiar a otro estado
            if (_enemy.EnemyState == EnemyState.Attack)
            {
                _enemy.ChangeState(EnemyState.Chase);
            }
        }
    }
}
