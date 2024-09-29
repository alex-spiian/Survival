using Survival;

namespace Survival.UI
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