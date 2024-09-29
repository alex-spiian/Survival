using UnityHFSM;

namespace Survival.Enemy
{
    public class ChaserAI : Enemy
    {
        protected override void CreateStateMachine()
        {
            StateMachine = new StateMachine();

            var idleMoveSet = new Idle(Animator);
            var idleStateName = nameof(IdleState);
            var idleState = new IdleState(idleMoveSet, false);

            var moveToPointMoveSet = new MoveToPoint(transform, TargetTransform, Animator, Speed);
            var chaseStateName = nameof(ChaseState);
            var chaseState = new ChaseState(moveToPointMoveSet, true);
            
            StateMachine.AddState(chaseStateName, chaseState);
            StateMachine.SetStartState(chaseStateName);
            StateMachine.AddState(idleStateName, idleState);
            StateMachine.Init();
        }
    }
}