using Survival.UI;
using UniTaskPubSub;
using UnityEngine;
using VContainer;

namespace Survival.Player
{
    public class ItemDetector : MonoBehaviour
    {
        private IAsyncPublisher _publisher;

        [Inject]
        public void Construct(IAsyncPublisher publisher)
        {
            _publisher = publisher;
        }
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<Weapons.Item>(out var item))
            {
                ScreensManager.OpenScreen<FoundItemScreen, FoundItemContext>(new FoundItemContext(item.ItemConfig, item));
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.CompareTag(GlobalConstants.ITEM_TAG))
            {
                _publisher.Publish(new FoundItemScreenClosedEvent());
            }
        }
    }
}