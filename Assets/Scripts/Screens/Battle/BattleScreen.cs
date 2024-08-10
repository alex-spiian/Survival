using Inventory;
using JetBrains.Annotations;
using ScreenManager.Core;
using Screens.Inventory;
using VContainer;

namespace Battle
{
    public class BattleScreen : UIScreen<BattleContext>
    {
        private BattleContext _context;
        private InventoryModel _inventoryModel;

        public override void Initialize(BattleContext context)
        {
            _context = context;
        }

        [Inject]
        public void Construct(InventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
        }
        
        [UsedImplicitly]
        public void OnInventoryOpened()
        {
            ScreensManager.OpenScreen<InventoryScreen, InventoryContext>(new InventoryContext(_inventoryModel));
        }
    }
}