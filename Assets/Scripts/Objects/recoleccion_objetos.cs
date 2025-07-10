using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public enum ItemType { Bullet, Medkit, MachinePieces }
    public ItemType itemType;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInventory inventory = collision.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                switch (itemType)
                {
                    case ItemType.Bullet:
                        inventory.AddBullets(amount);
                        break;
                    case ItemType.Medkit:
                        inventory.AddMedkits(amount);
                        break;
                    case ItemType.MachinePieces:
                        inventory.AddPieces(amount);
                        break;

                }
                Destroy(gameObject); // Desaparece el ítem tras recogerlo
            }
        }
    }
}
