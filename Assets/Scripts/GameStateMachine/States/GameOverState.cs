using UnityHFSM;

namespace Survival.GameStateMachine
{
    public class GameOverState : StateBase
    {
        public GameOverState(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            // provide parameters you need
        }
    }
}