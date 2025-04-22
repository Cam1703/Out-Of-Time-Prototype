using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f; // Máxima salud del jugador
    [SerializeField] private float _healObjetctHeal = 20f;
    private float _currentHealth = 100;
    private int _healObjectQuantity = 3;
    private bool isDead = false;

    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int HealObjectQuantity { get => _healObjectQuantity; set => _healObjectQuantity = value; }

    private void Update()
    {
        if (InputManager.IsHealPressed())
        {
            UseHealObject();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return; // Si el jugador ya está muerto, no se puede recibir más daño
        _currentHealth -= damage;
        UIManager.Instance.UpdateHealthText();
        if (_currentHealth <= 0) isDead = true;
    }

    public void UseHealObject() { 
        if(_healObjectQuantity > 0)
        {
            _currentHealth += _healObjetctHeal;
            _healObjectQuantity--;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            UIManager.Instance.UpdateHealthText();
            UIManager.Instance.UpdateHealersText();
        }
    }
}
