using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    private Player player;
    private InventoryManager inventoryManager;

    void Start()
    {
        player = GameManager.instance.player;
        inventoryManager = player.inventoryManager;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RemoveOneSeed();
        }
    }

    void RemoveOneSeed()
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
