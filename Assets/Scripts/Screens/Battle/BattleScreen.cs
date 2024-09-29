using Survival;
using JetBrains.Annotations;
using ScreenManager.Core;
using Survival.UI;
using Survival.UI.Events;
using Survival.UI.Warning;
using SimpleEventBus.Disposables;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.UI
{
    public class BattleScreen : UIScreen<BattleContext>
    {
        [SerializeField]
        private Transform _inventoryButton;
        
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
            ScreensManager.OpenScreen<PopUpWarningScreen, PopUpWarningContext>
                (new PopUpWarningContext(header, content, _inventoryButton));
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}