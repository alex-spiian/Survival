using FoundItem;
using Inventory;
using Screens.Inventory.Events;
using SimpleEventBus.Disposables;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private WeaponHolder _weaponHolder;
        private readonly CompositeDisposable _subscriptions = new();
        private InventoryModel _inventory;
        private IAsyncPublisher _publisher;

        [Inject]
        public void Construct(IAsyncSubscriber subscriber, IAsyncPublisher publisher, InventoryModel inventory)
        {
            _publisher = publisher;
            _inventory = inventory;
            _subscriptions.Add(subscriber.Subscribe<WeaponPickedUpEvent>(OnWeaponPickedUp));
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent eventData)
        {
            if (_weaponHolder.TrySetWeapon(eventData.Weapon))
            {
                _inventory.AddWeapon(eventData.Weapon);
                return;
            }
            
            _publisher.Publish(new InventoryIsFullEvent());
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}