using System;
using SimpleEventBus.Disposables;
using UniTaskPubSub;
using UnityHFSM;
using VContainer.Unity;

namespace Survival.GameStateMachine
{
    public class GameStateMachine : IStartable, IDisposable
    {
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions = new();

        public GameStateMachine(GameStates gameStates, IAsyncSubscriber subscriber)
        {
            _stateMachine = new StateMachine();
            foreach (var state in gameStates.AllStates)
            {
                var stateName = state.GetType().Name;
                _stateMachine.AddState(stateName, state);
            }
            
            _subscriptions.Add(subscriber.Subscribe<BootstrapCompletedEvent>(_ =>
                _stateMachine.RequestStateChange(nameof(PreparationState))));
            
            _subscriptions.Add(subscriber.Subscribe<PreparationEndedEvent>(_ =>
                _stateMachine.RequestStateChange(nameof(FightState))));
            
            _subscriptions.Add(subscriber.Subscribe<GameOverEvent>(_ =>
                _stateMachine.RequestStateChange(nameof(GameOverState))));
        }

        public void Start()
        {
            _stateMachine.SetStartState(nameof(BootstrapState));
            _stateMachine.Init();
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}