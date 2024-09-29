using UnityHFSM;

namespace Survival.GameStateMachine
{
    public class GameStates
    {
        public StateBase[] AllStates => new StateBase[]
        {
            _bootstrapState,
            _preparationState,
            _fightState,
            _gameOverState,
        };

        private BootstrapState _bootstrapState;
        private PreparationState _preparationState;
        private FightState _fightState;
        private GameOverState _gameOverState;

        public GameStates(BootstrapState bootstrapState,
            PreparationState preparationState,
            FightState fightState,
            GameOverState gameOverState)
        {
            _bootstrapState = bootstrapState;
            _preparationState = preparationState;
            _fightState = fightState;
            _gameOverState = gameOverState;
        }
    }
}