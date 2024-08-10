using FoundItem;
using Inventory;
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

        [Inject]
        public void Construct(IAsyncSubscriber subscriber, InventoryModel inventory)
        {
            _inventory = inventory;
            _subscriptions.Add(subscriber.Subscribe<WeaponPickedUpEvent>(OnWeaponPickedUp));
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent eventData)
        {
            if (_weaponHolder.TrySetWeapon(eventData.Weapon))
            {
                _inventory.AddWeapon(eventData.Weapon);
            }
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}