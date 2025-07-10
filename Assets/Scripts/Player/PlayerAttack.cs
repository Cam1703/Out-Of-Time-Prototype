using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Malee attack
    [SerializeField] private GameObject _malee;

    [SerializeField] private bool _isAttacking = false;
    [SerializeField] private float _attackDuration = 0.3f;
    [SerializeField] private float _attackTimer = 0f;

    //Range Attack
    [SerializeField] private Transform _aim;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _fireForce = 10f;
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _shootTimer = 0.5f;

    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMaleeTimer();
        CheckShootTimer();

        if (InputManager.IsMaleeAttackPressed())
        {
            OnMaleeAttack();
        }

        if (InputManager.IsAttackShootPressed()) 
        {
            OnShoot();
        }
    }

    private void OnMaleeAttack()
    {
        if (_isAttacking) return;

        _isAttacking = true;
        _malee.SetActive(true);

        _playerAnimation.MaleeAttackAnimation();
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

    private void OnShoot()
    {
        if(_shootTimer > _shootCooldown)
        {
            _playerAnimation.ShootAnimation();
            _shootTimer = 0;
            GameObject bullet = Instantiate(_bullet, _aim.position, _aim.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(-_aim.up * _fireForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
        }
    }

    private void CheckShootTimer()
    {
        _shootTimer += Time.deltaTime;
    }
}
