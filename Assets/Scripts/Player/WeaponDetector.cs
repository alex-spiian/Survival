using Survival.UI;
using UniTaskPubSub;
using UnityEngine;
using VContainer;
using Survival.Weapons;

namespace Survival.Player
{
    public class WeaponDetector : MonoBehaviour
    {
        private IAsyncPublisher _publisher;

        [Inject]
        public void Construct(IAsyncPublisher publisher)
        {
            _publisher = publisher;
        }
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Weapon>(out var weapon))
            {
                ScreensManager.OpenScreen<FoundItemScreen, FoundItemContext>(new FoundItemContext(weapon.WeaponConfig, weapon));
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.CompareTag(GlobalConstants.WEAPON_TAG))
            {
                _publisher.Publish(new FoundItemScreenClosedEvent());
            }
        }
    }
}