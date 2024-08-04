using ScreenManager.Core;

namespace Battle
{
    public class BattleScreen : UIScreen<BattleContext>
    {
        private BattleContext _context;

        public override void Initialize(BattleContext context)
        {
            _context = context;
        }
    }
}