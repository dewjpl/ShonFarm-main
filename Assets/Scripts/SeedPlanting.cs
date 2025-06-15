using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    [Header("Ustawienia sadzenia")]
    public GameObject seedPrefab; // Prefab rośliny, np. nasiona
    public float plantDistance = 1f; // Odległość sadzenia przed graczem

    [Header("Referencje")]
    public Transform playerTransform; // Gracz (Transform)
    public Inventory inventory; // Ekwipunek gracza

    [Header("Nazwa nasion w ekwipunku")]
   public string seedItemName = "crops_all_0";
// Dokładna nazwa przedmiotu w inventory

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // PPM - sadzenie
        {
            TryPlantSeed();
        }
    }

    void TryPlantSeed()
    {
        Debug.Log("Próba zasadzenia");

        if (inventory == null)
        {
            Debug.Log("Brak przypisanego ekwipunku!");
            return;
        }

        if (!inventory.HasItem(seedItemName))
        {
            Debug.Log("Brak nasion w ekwipunku!");
            return;
        }

        // Oblicz pozycję przed graczem (w kierunku patrzenia)
        Vector2 plantPosition = playerTransform.position + playerTransform.up * plantDistance;

        // Stwórz roślinę
        Instantiate(seedPrefab, plantPosition, Quaternion.identity);

        // Usuń jedno nasiono z ekwipunku
        inventory.RemoveItem(seedItemName);

        Debug.Log("Zasadzono nasiono!");
    }
}
