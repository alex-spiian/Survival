using Inventory;
using JetBrains.Annotations;
using ScreenManager.Core;
using Screens.Inventory;
using Screens.Inventory.Events;
using Screens.Warning;
using SimpleEventBus.Disposables;
using UniTaskPubSub;
using VContainer;

namespace Battle
{
    public class BattleScreen : UIScreen<BattleContext>
    {
        private BattleContext _context;
        private InventoryModel _inventoryModel;

        private readonly CompositeDisposable _subscriptions = new();

        public override void Initialize(BattleContext context)
        {
            _context = context;
        }

        [Inject]
        public void Construct(InventoryModel inventoryModel, IAsyncSubscriber subscriber)
        {
            _inventoryModel = inventoryModel;
            _subscriptions.Add(subscriber.Subscribe<InventoryIsFullEvent>(_ => OnInventoryIsFull()));
        }
        
        [UsedImplicitly]
        public void OnInventoryOpened()
        {
            ScreensManager.OpenScreen<InventoryScreen, InventoryContext>(new InventoryContext(_inventoryModel));
        }

        private void OnInventoryIsFull()
        {
            var header = "YOU ARE FULL!";
            var content = "If you wanna pick up this weapon you first need to drop the current one!";
            ScreensManager.OpenScreen<PopUpWarningScreen, PopUpWarningContext>(new PopUpWarningContext(header, content));
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}