using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using ScreenManager.Core;
using Screens.Inventory;
using SimpleEventBus.Disposables;
using UniTaskPubSub;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace FoundItem
{
    public class FoundItemScreen : UIScreen<FoundItemContext>
    {
        [Header("Configurations")]
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private float _scaleDuration = 0.2f;
        [SerializeField] private float _maxTransparencyValue = 0.9f;
        
        [Header("Components")]
        [SerializeField] private Image _background;
        [SerializeField] private FoundItemTooltip _tooltip;
        [SerializeField] private Button _pickUpButton;

        private IAsyncPublisher _publisher;
        private FoundItemContext _context;
        private readonly CompositeDisposable _subscriptions = new();

        public override void Initialize(FoundItemContext context)
        {
            _context = context;
            _tooltip.Initialize(_context.ItemConfig);
            OpenSmoothly();
            ScreensManager.CloseScreen<InventoryScreen>();
        }

        [Inject]
        public void Construct(IAsyncPublisher publisher, IAsyncSubscriber subscriber)
        {
            _publisher = publisher;
            _subscriptions.Add(subscriber.Subscribe<FoundItemScreenClosedEvent>(_ => OnScreenClosed()));
        }

        [UsedImplicitly]
        public void OnItemPickedUp()
        {
            _publisher.PublishAsync(new WeaponPickedUpEvent(_context.Weapon));
        }

        private async void OnScreenClosed()
        {
            CloseSmoothly();
            await UniTask.WaitForSeconds(_fadeDuration);
            CloseScreen();
        }

        private void OpenSmoothly()
        {
            FadeImageSmoothly(_maxTransparencyValue);
            ScaleSmoothly(_tooltip.transform, Vector3.one);
            ScaleSmoothly(_pickUpButton.transform, Vector3.one);
        }
        
        private void CloseSmoothly()
        {
            FadeImageSmoothly(0f);
            ScaleSmoothly(_tooltip.transform, Vector3.zero);
            ScaleSmoothly(_pickUpButton.transform, Vector3.zero);
        }

        private void FadeImageSmoothly(float targetValue)
        {
            _background.DOFade(targetValue, _fadeDuration);
        }

        private void ScaleSmoothly(Transform objectToScale, Vector3 targetScale)
        {
            objectToScale.DOScale(targetScale, _scaleDuration);
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}