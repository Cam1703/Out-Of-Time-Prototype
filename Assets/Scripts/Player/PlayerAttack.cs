using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _malee;

    [Tooltip ("Attack Parameters")]
    [SerializeField] private bool _isAttacking = false;
    [SerializeField] private float _attackDuration = 0.3f;
    [SerializeField] private float _attackTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        CheckMaleeTimer();
        if (InputManager.IsMaleeAttackPressed())
        {
            OnMaleeAttack();
        }
    }

    private void OnMaleeAttack()
    {
        if (_isAttacking) return;

        _isAttacking = true;
        _malee.SetActive(true);

        //TO_DO: Animación de ataque
    }

    private void CheckMaleeTimer()
    {
        if (!_isAttacking) return;

        _attackTimer += Time.deltaTime;

        if( _attackTimer >= _attackDuration)
        {
            _attackTimer = 0;
            _isAttacking = false;
            _malee.SetActive(false);
        }
    }
}
