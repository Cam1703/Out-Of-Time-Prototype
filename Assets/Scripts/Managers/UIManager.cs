using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _healersText;
    [SerializeField] private TMP_Text _bulletsText;

    private PlayerHealth _playerHealth;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth Component not found");
            return;
        }

        _healthText.text = "Lives: " + _playerHealth.CurrentHealth.ToString();
        _healersText.text = "Healers: " + _playerHealth.HealObjectQuantity.ToString();
        _bulletsText.text = "Bullets: 0";

    }

    public void UpdateHealthText()
    {
        _healthText.text = "Lives: " + _playerHealth.CurrentHealth.ToString();
    }

    public void UpdateHealersText()
    {
        _healersText.text = "Healers: " + _playerHealth.HealObjectQuantity.ToString();
    }

    public void UpdateBulletsText(int bulletCount)
    {
        _bulletsText.text = "Bullets: " + bulletCount.ToString();
    }

}
