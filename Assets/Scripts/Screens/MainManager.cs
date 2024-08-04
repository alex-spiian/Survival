using Battle;
using UnityEngine;

namespace Screens
{
    public class MainManager : MonoBehaviour
    {
        private void Start()
        {
            ScreensManager.OpenScreen<BattleScreen, BattleContext>(new BattleContext());
        }
    }
}