using UnityHFSM;

namespace Survival.GameStateMachine
{
    public class FightState : StateBase
    {
        public FightState(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            // provide parameters you need
        }
    }
}