using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _healObjetctHeal = 20f;
    [SerializeField] private float _inmunityDuration = 0.5f;

    private float _currentHealth;
    private float _inmunityTimer = 0f;
    private int _healObjectQuantity = 3;
    private bool isDead = false;
    private PlayerAnimation _playerAnimation;

    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int HealObjectQuantity { get => _healObjectQuantity; set => _healObjectQuantity = value; }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Update()
    {
        // Reducir el tiempo de inmunidad con el tiempo
        if (_inmunityTimer > 0)
            _inmunityTimer -= Time.deltaTime;

        if (InputManager.IsHealPressed())
        {
            UseHealObject();
        }
    }

    public void TakeDamage(float damage)
    {
        if (_inmunityTimer > 0 || isDead)
            return;

        _currentHealth -= damage;
        UIManager.Instance.UpdateHealthText();
        _playerAnimation.HurtAnimation();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            isDead = true;
            // Aquí podrías llamar una animación de muerte, desactivar controles, etc.
        }

        _inmunityTimer = _inmunityDuration; // Activar inmunidad tras recibir daño
    }

    public void UseHealObject()
    {
        if (_healObjectQuantity > 0 && !isDead)
        {
            _currentHealth += _healObjetctHeal;
            _healObjectQuantity--;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;

            UIManager.Instance.UpdateHealthText();
            UIManager.Instance.UpdateHealersText();
        }
    }
}
