using UnityHFSM;

namespace Survival.Enemy
{
    public class ChaserAI : Enemy
    {
        protected override void CreateStateMachine()
        {
            StateMachine = new StateMachine();

            var moveToPointMoveSet = new MoveToPoint(transform, TargetTransform, Animator, Speed);
            var chaseStateName = nameof(ChaseState);
            var chaseState = new ChaseState(moveToPointMoveSet, false);
            
            StateMachine.AddState(chaseStateName, chaseState);
            StateMachine.SetStartState(chaseStateName);
            StateMachine.Init();
        }
    }
}