using UnityEngine;
using UnityHFSM;

namespace Survival.GameStateMachine
{
    public class PreparationState : StateBase
    {
        public PreparationState(bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            // provide parameters you need
        }

        public override void OnEnter()
        {
            Debug.Log("PreparationState Enter");
        }
    }
}