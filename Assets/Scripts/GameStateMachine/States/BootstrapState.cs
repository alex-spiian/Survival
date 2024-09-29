using UniTaskPubSub;
using UnityHFSM;

namespace Survival.GameStateMachine
{
    public class BootstrapState : StateBase
    {
        private IAsyncPublisher _publisher;
        private EnemySpawner _enemySpawner;

        public BootstrapState(IAsyncPublisher publisher,
            EnemySpawner enemySpawner,
            bool needsExitTime,
            bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            // provide parameters you need to initialize
            _publisher = publisher;
            _enemySpawner = enemySpawner;
        }

        public override void OnEnter()
        {
            // initialize everything you want here
            _enemySpawner.Spawn();
            _publisher.Publish(new BootstrapCompletedEvent());
        }
    }
}