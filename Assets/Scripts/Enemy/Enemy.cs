using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 30f;
    [SerializeField] private float _damage = 10f;

    private EnemyState _enemyState = EnemyState.Idle;
    private EnemyAnimation _enemyAnimation;

    public EnemyState EnemyState { get => _enemyState; set => _enemyState = value; }

    public void Start()
    {
        ChangeState(EnemyState.Idle);
        _enemyAnimation = GetComponentInChildren<EnemyAnimation>();
    }

    public void TakeDamage(float damage)
    {
        if (_enemyAnimation != null)
        {
            _enemyAnimation.HurtAnimation(); 
        }
        _health -= damage;
        if (_health <= 0) Destroy(gameObject);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificar si el jugador tiene un componente de salud
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Aplicar daño al jugador
                playerHealth.TakeDamage(_damage);
            }

        }
    }



    public void ChangeState(EnemyState newState)
    {
        if (newState == _enemyState) { 
            //Debug.Log("Enemy is already in the state: " + newState);
            return; 
        }
        if(newState == EnemyState.Idle)
        {
           // Debug.Log("Enemy is now idle");
            _enemyState = newState;
            _enemyAnimation.SetIdleAnimation();
        }
        if(newState == EnemyState.Chase)
        {
            _enemyState = newState;
           // Debug.Log("Enemy is now chasing");
            _enemyAnimation.SetRunAnimation();
        }
        if (newState == EnemyState.Attack)
        {
            _enemyState = newState;
           // Debug.Log("Enemy is now attacking");
            _enemyAnimation.MaleeAttackAnimation();
        }
        if (newState == EnemyState.Patrol)
        {
            _enemyState = newState;
            //Debug.Log("Enemy is now patrolling");
            _enemyAnimation.SetRunAnimation();
        }
    }
}

public enum EnemyState
{
    Idle,
    Patrol,
    Chase,
    Attack,
    Dead
}
