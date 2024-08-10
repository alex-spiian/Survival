using FoundItem;
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

        [Inject]
        public void Construct(IAsyncSubscriber subscriber)
        {
            _subscriptions.Add(subscriber.Subscribe<WeaponPickedUpEvent>(OnWeaponPickedUp));
        }

        private void OnWeaponPickedUp(WeaponPickedUpEvent eventData)
        {
            _weaponHolder.SetWeapon(eventData.Weapon);
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}