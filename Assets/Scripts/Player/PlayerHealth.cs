using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _healObjetctHeal = 20f;
    [SerializeField] private float _inmunityDuration = 0.5f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private int _healObjectQuantity;
    [SerializeField] private int _machinePieces;

    private float _inmunityTimer = 0f;
    //private int _healObjectQuantity;
    private bool isDead = false;
    private PlayerAnimation _playerAnimation;
    private GameObject part1;
    private GameObject part2;
    private GameObject part3;
    private GameObject part4;
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int HealObjectQuantity { get => _healObjectQuantity; set => _healObjectQuantity = value; }

    public int MachinePieces { get => _machinePieces; set => _machinePieces = value; }


    private void Awake()
    {
        // Establecer valores predeterminados si no existen en PlayerPrefs
        if (!PlayerPrefs.HasKey("PlayerHealth"))
        {
            _currentHealth = _maxHealth;  // Salud por defecto (100)
            _healObjectQuantity = 3;      // Objetos curativos por defecto (3)
            _machinePieces = 0;
        }
        else
        {
            // Cargar los datos guardados si existen
            _currentHealth = PlayerPrefs.GetFloat("PlayerHealth", _maxHealth);
            _healObjectQuantity = PlayerPrefs.GetInt("HealObjects", 3);
            _machinePieces = PlayerPrefs.GetInt("MachinePieces", 0);
        }
        if(_machinePieces >0)
        {
            part1 = GameObject.FindGameObjectWithTag("part_one");
            part2 = GameObject.FindGameObjectWithTag("part_two");
            part3 = GameObject.FindGameObjectWithTag("part_three");
            part4 = GameObject.FindGameObjectWithTag("part_four");

            if(_machinePieces == 1) part1.SetActive(false);
            if (_machinePieces == 2)
            {
                part1.SetActive(false);
                part2.SetActive(false);

            }
            if (_machinePieces == 3)
            {
                part1.SetActive(false);
                part2.SetActive(false);
                part3 .SetActive(false);

            }
            if (_machinePieces == 4)
            {
                part1.SetActive(false);
                part2.SetActive(false);
                part3.SetActive(false);
                part4 .SetActive(false);

            }


        }




        Debug.Log("sucede awake");
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
        if (_playerAnimation == null)
        {
            Debug.LogError("El componente PlayerAnimation no se ha asignado correctamente.");
        }
    }

    private void Start()
    {
        LoadPlayerData();
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

        UIManager.Instance.UpdateHealthTextWithValue(_currentHealth);  // Actualiza la UI con la nueva salud
        //UIManager.Instance.UpdateHealth();

        if (_playerAnimation != null)
        {
            _playerAnimation.HurtAnimation();  // Llamar a la animaci�n de da�o
        }

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            isDead = true;
            // Llamamos a la funci�n para reiniciar el nivel
            Invoke("ResetLevel", 2f);  // Esperar 2 segundos antes de reiniciar la escena
        }

        _inmunityTimer = _inmunityDuration;  // Activar inmunidad tras recibir da�o
    }

    public void UseHealObject()
    {
        if (_healObjectQuantity > 0 && !isDead)
        {
            _currentHealth += _healObjetctHeal;
            _healObjectQuantity--;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;

            /*UIManager.Instance.UpdateHealthText();
            UIManager.Instance.UpdateHealersText();*/
            UIManager.Instance.UpdateHealthTextWithValue(_currentHealth);
            UIManager.Instance.UpdateHealersTextWithValue(_healObjectQuantity);


        }
    }

    // M�todo para cargar los datos del progreso solo cuando muere el jugador
    public void LoadPlayerData()
    {
        // Cargar la salud del jugador desde PlayerPrefs si ya existen datos guardados
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            _currentHealth = PlayerPrefs.GetFloat("PlayerHealth", _maxHealth);
            _healObjectQuantity = PlayerPrefs.GetInt("HealObjects", 3);
            _machinePieces = PlayerPrefs.GetInt("MachinePieces", 0);
            Debug.Log($"piezas con valor a ui se manda  {_machinePieces}");
        }

        // Cargar la posici�n del jugador
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            float posX = PlayerPrefs.GetFloat("PlayerPosX");
            float posY = PlayerPrefs.GetFloat("PlayerPosY");
            float posZ = PlayerPrefs.GetFloat("PlayerPosZ");
            transform.position = new Vector3(posX, posY, posZ);
        }
        Debug.Log("se prepara para carga datos");
        // Actualizamos la UI con los datos cargados
        if (UIManager.Instance != null)
        {
            Debug.Log("carga datos");
            /*UIManager.Instance.UpdateHealthText();
            UIManager.Instance.UpdateHealersText();*/
            UIManager.Instance.UpdateHealthTextWithValue(_currentHealth);
            UIManager.Instance.UpdateHealersTextWithValue(_healObjectQuantity);
            UIManager.Instance.UpdateBulletsTextWithValue(0);
            UIManager.Instance.UpdatePiecesTextWithValue(_machinePieces);
            
        }
    }

    // M�todo para guardar el progreso
    public void SaveProgress()
    {
        PlayerPrefs.SetFloat("PlayerHealth", _currentHealth);
        PlayerPrefs.SetInt("HealObjects", _healObjectQuantity);
        PlayerPrefs.SetInt("MachinePieces", _machinePieces);
        // Guardar la posici�n del jugador
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);

        PlayerPrefs.Save();
    }

    // M�todo para reiniciar el nivel
    public void ResetLevel()
    {
        // Llamamos a SceneManager para recargar la escena
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);  // Reiniciamos la misma escena

        Debug.Log($"piezas con valor a ui 1 se manda  {_machinePieces}");
        _currentHealth = _maxHealth;  // Restaurar la salud a 100 al reiniciar
        _healObjectQuantity = 3;      // Restaurar los objetos curativos a 3
        _machinePieces = 0;


        /*
        // Cargar los datos del jugador despu�s de que la escena se haya reiniciado
        Invoke("LoadPlayerData", 0.8f); // Esperamos un breve momento para que la escena termine de reiniciarse antes de cargar los datos*/
    }
}
