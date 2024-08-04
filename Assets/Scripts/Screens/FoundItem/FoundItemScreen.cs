using JetBrains.Annotations;
using ScreenManager.Core;
using UniTaskPubSub;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace FoundItem
{
    public class FoundItemScreen : UIScreen<FoundItemContext>
    {
        [SerializeField]
        private Image _background;
        
        [SerializeField]
        private FoundItemTooltip _tooltip;

        private IAsyncPublisher _publisher;
        private FoundItemContext _context;

        public override void Initialize(FoundItemContext context)
        {
            _context = context;
            _tooltip.Initialize(_context.ItemConfig);
        }

        [Inject]
        public void Construct(IAsyncPublisher publisher)
        {
            _publisher = publisher;
        }

        [UsedImplicitly]
        public void OnItemPickedUp()
        {
            _publisher.PublishAsync(new WeaponPickedUpEvent(_context.Weapon));
        }
    }
}