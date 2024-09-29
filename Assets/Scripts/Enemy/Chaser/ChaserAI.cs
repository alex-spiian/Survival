using UnityHFSM;

namespace Survival
{
    public class ChaserAI : Enemy
    {
        protected override void CreateStateMachine()
        {
            StateMachine = new StateMachine();

            //var idleMoveSet = new Idle(Animator, Rigidbody);
            //var idleStateName = nameof(IdleState);
            //var idleState = new IdleState(idleMoveSet, false);

            var moveToPointMoveSet = new MoveToPoint(transform, TargetTransform, Animator, Speed);
            var chaseStateName = nameof(ChaseState);
            var chaseState = new ChaseState(moveToPointMoveSet, true);
            
            StateMachine.AddState(chaseStateName, chaseState);
            
            //StateMachine.AddState(idleStateName, idleState);
            StateMachine.Init();
        }
    }
}