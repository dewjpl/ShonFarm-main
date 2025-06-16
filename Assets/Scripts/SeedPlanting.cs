using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    private Player player;
    private InventoryManager inventoryManager;
    private TileManager tileManager;

    void Start()
    {
        player = GameManager.instance.player;
        inventoryManager = player.inventoryManager;
        tileManager = GameManager.instance.tileManager;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TryPlantSeed();
        }
    }

    void TryPlantSeed()
    {
        var toolbar = inventoryManager.toolbar;
        var selectedSlot = toolbar.selectedSlot;

        if (selectedSlot == null || string.IsNullOrEmpty(selectedSlot.itemName))
        {
            return;
        }

        var item = GameManager.instance.itemManager.GetItemByName(selectedSlot.itemName);
        var itemData = item?.data;
        if (itemData == null || !itemData.isSeed)
        {
            return;
        }

        Vector3Int tilePos = new Vector3Int(
            Mathf.FloorToInt(player.transform.position.x),
            Mathf.FloorToInt(player.transform.position.y),
            0
        );
        string tileName = tileManager.GetTileName(tilePos);

        if (tileName != "summer_plowed")
        {
            return;
        }

        if (selectedSlot.count <= 0)
        {
            return;
        }

        selectedSlot.count--;
        if (selectedSlot.count == 0)
        {
            selectedSlot.itemName = "";
            selectedSlot.icon = null;
        }

        GameManager.instance.uiManager.RefreshAll();
    }
}
