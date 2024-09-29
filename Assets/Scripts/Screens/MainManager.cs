using Survival.UI;
using UnityEngine;

namespace Survival.UI
{
    public class MainManager : MonoBehaviour
    {
        private void Start()
        {
            ScreensManager.OpenScreen<BattleScreen, BattleContext>(new BattleContext());
        }
    }
}