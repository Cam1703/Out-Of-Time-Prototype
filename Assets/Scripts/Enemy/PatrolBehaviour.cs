using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 2f; // Velocidad de patrulla
    [SerializeField] private Transform[] _patrolPoints; // Puntos de patrulla

    private int _currentPatrolIndex = 0; // Índice del punto actual
    private Enemy _enemy; // Referencia al script Enemy

    private void Awake()
    {
        _enemy = GetComponent<Enemy>(); // Obtiene la referencia al script Enemy
        if (_patrolPoints == null || _patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points assigned to " + gameObject.name);
        }
    }

    private void Update()
    {
        if (_patrolPoints == null || _patrolPoints.Length == 0)
            return;

        _enemy.ChangeState(EnemyState.Patrol); // Cambia el estado del enemigo a Patrol

        // Obtiene la posición del punto de patrulla actual
        Transform targetPoint = _patrolPoints[_currentPatrolIndex];

        // --- Flop (flip) dirección según el punto de patrulla ---
        Vector3 direction = targetPoint.position - transform.position;
        if (direction.x != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Sign(direction.x) * Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }

        // Mueve el enemigo hacia el punto de patrulla actual
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            _speed * Time.deltaTime
        );

        // Si ha llegado al punto de patrulla, avanza al siguiente
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            _currentPatrolIndex++;
            if (_currentPatrolIndex >= _patrolPoints.Length)
                _currentPatrolIndex = 0; // Reinicia el ciclo
        }
    }
}
