using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int bullets = 0;
    public int healers = 0;
    public int pieces = 0;
    private PlayerHealth _playerHealth;

    void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void AddBullets(int amount)
    {
        bullets += amount;
        Debug.Log("Balas: " + bullets);
        UIManager.Instance.UpdateBulletsText(bullets); 

    }

    public void AddMedkits(int amount)
    {
        _playerHealth.HealObjectQuantity += amount;
        UIManager.Instance.UpdateHealersTextWithValue(_playerHealth.HealObjectQuantity);
    }

    public void AddPieces(int amount)
    {
        _playerHealth.MachinePieces += amount;
        UIManager.Instance.UpdatePiecesTextWithValue(_playerHealth.MachinePieces);
    }


}
