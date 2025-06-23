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
            //DontDestroyOnLoad(gameObject);
        }

        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth Component not found");
            return;
        }
        _healthText.text = "Lives: " + _playerHealth.CurrentHealth.ToString();
        _healersText.text = "Healers: " + _playerHealth.HealObjectQuantity.ToString();
        _bulletsText.text = "Bullets: 0";
        Debug.Log($"la vida al crear UIMANAGER es {_healthText.text}");
    }
    void Start()
    {
        /*_playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth Component not found");
            return;
        }
        _healthText.text = "Lives: " + _playerHealth.CurrentHealth.ToString();
        _healersText.text = "Healers: " + _playerHealth.HealObjectQuantity.ToString();
        _bulletsText.text = "Bullets: 0";*/

    }

    public void UpdateHealthText()
    {
        _healthText.text = "Lives: " + _playerHealth.CurrentHealth.ToString();
        Debug.Log($"la vida es {_healthText.text}");
    }

    public void UpdateHealersText()
    {
        _healersText.text = "Healers: " + _playerHealth.HealObjectQuantity.ToString();
        Debug.Log($"la vida es {_healersText.text}");
    }

    public void UpdateBulletsText(int bulletCount)
    {
        _bulletsText.text = "Bullets: " + bulletCount.ToString();
    }

    public void UpdateHealthTextWithValue(float health)
    {
        _healthText.text = "Lives: " + health.ToString();
        //Debug.Log($"la vida es {_healthText.text}");
    }

    public void UpdateHealersTextWithValue(int health)
    {
        _healersText.text = "Healers: " + health.ToString();
        //Debug.Log($"la vida es {_healersText.text}");
    }
    public void UpdateBulletsTextWithValue(int bulletCount)
    {
        _bulletsText.text = "Bullets: " + bulletCount.ToString();
    }


}
