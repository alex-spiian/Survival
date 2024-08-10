using Inventory;

namespace Screens.Inventory
{
    public class InventoryContext
    {
        public InventoryModel InventoryModel { get; }

        public InventoryContext(InventoryModel inventoryModel)
        {
            InventoryModel = inventoryModel;
        }
    }
}