using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using ScreenManager.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Warning
{
    public class PopUpWarningScreen : UIScreen<PopUpWarningContext>
    {
        [Header("Configurations")]
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private float _scaleDuration = 0.2f;
        [SerializeField] private float _maxTransparencyValue = 0.9f;
        
        [Header("Components")]
        [SerializeField] private WarningMessage _warningMessage;
        [SerializeField] private Image _background;
        [SerializeField] private Transform _arrowPointer;

        public override void Initialize(PopUpWarningContext context)
        {
            _warningMessage.Initialize(context.Header, context.Content);
            OpenSmoothly();
            SetArrowPointer(context.ObjectToPayAttention.position);
        }

        [UsedImplicitly]
        public override async void CloseScreen()
        {
            FadeImageSmoothly(0f);
            ScaleSmoothly(_warningMessage.transform, Vector3.zero);
            ScaleSmoothly(_arrowPointer, Vector3.zero);
            await UniTask.WaitForSeconds(_fadeDuration);
            base.CloseScreen();
        }

        private void SetArrowPointer(Vector3 position)
        {
            _arrowPointer.position = position;
        }
        private void OpenSmoothly()
        {
            FadeImageSmoothly(_maxTransparencyValue);
            ScaleSmoothly(_warningMessage.transform, Vector3.one);
            ScaleSmoothly(_arrowPointer, Vector3.one);
        }
        
        private void FadeImageSmoothly(float targetValue)
        {
            _background.DOFade(targetValue, _fadeDuration);
        }

        private void ScaleSmoothly(Transform objectToScale, Vector3 targetScale)
        {
            objectToScale.DOScale(targetScale, _scaleDuration);
        }
    }
}