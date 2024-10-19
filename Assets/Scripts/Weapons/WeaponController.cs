using SimpleEventBus.Disposables;
using Survival.Events;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private WeaponHolder _weaponHolder;
        private readonly CompositeDisposable _subscriptions = new();

        [Inject]
        public void Construct(IAsyncSubscriber subscriber)
        {
            _subscriptions.Add(subscriber.Subscribe<WeaponPickedUpEvent>(OnWeaponPickedUp));
            _subscriptions.Add(subscriber.Subscribe<WeaponDroppedEvent>(OnWeaponDropped));
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent eventData)
        {
            _weaponHolder.TrySetWeapon(eventData.WeaponConfig);
        }

        private void OnWeaponDropped(WeaponDroppedEvent eventData)
        {
            _weaponHolder.TryRemoveWeapon(eventData.WeaponConfig);
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}