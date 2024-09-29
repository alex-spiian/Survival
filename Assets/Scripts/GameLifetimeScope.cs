using Survival.GameStateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Survival
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private EnemySpawner _enemySpawner;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_enemySpawner);
            builder.Register<StandaloneInputHandler>(Lifetime.Singleton)
                .AsImplementedInterfaces();

            RegisterGameStateMachine(builder);
        }

        private void RegisterGameStateMachine(IContainerBuilder builder)
        {
            var needsExitTime = "needsExitTime";
            var isGhostState = "isGhostState";
            
            builder.Register<BootstrapState>(Lifetime.Singleton)
                .WithParameter(needsExitTime, false) 
                .WithParameter(isGhostState, false);
            
            builder.Register<PreparationState>(Lifetime.Singleton)
                .WithParameter(needsExitTime, false) 
                .WithParameter(isGhostState, false);
            
            builder.Register<FightState>(Lifetime.Singleton)
                .WithParameter(needsExitTime, false) 
                .WithParameter(isGhostState, false);
            builder.Register<GameOverState>(Lifetime.Singleton)
                
                .WithParameter(needsExitTime, false) 
                .WithParameter(isGhostState, false);
            
            builder.Register<GameStates>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<GameStateMachine.GameStateMachine>();
        }
    }
}
