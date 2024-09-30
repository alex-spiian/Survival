using UnityHFSM;

namespace Survival.Enemy
{
    public class ChaseState : StateBase
    {
        private MoveToPoint _moveToPoint;

        public ChaseState(MoveToPoint moveToPoint, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _moveToPoint = moveToPoint;
        }

        public override void OnLogic()
        {
            _moveToPoint.Move();
        }
    }
}