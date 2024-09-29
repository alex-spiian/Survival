using UnityEngine;
using UnityHFSM;

namespace Survival
{
    public class ChaseState : StateBase
    {
        private MoveToPoint _moveToPoint;

        public ChaseState(MoveToPoint moveToPoint, bool needsExitTime, bool isGhostState = false) : base(needsExitTime, isGhostState)
        {
            _moveToPoint = moveToPoint;
        }

        public override void OnEnter()
        {
            Debug.Log("ChaseState OnEnter");
        }

        public override void OnLogic()
        {
            Debug.Log("ChaseState on logic");
            _moveToPoint.Move();
        }
    }
}