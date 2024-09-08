using UnityHFSM;

namespace Enemy
{
    public class IdleState : StateBase
    {
        private Idle _idle;
        public IdleState(Idle idle, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _idle = idle;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _idle.Start();
        }
    }
}