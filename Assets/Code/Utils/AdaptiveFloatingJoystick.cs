using UnityEngine;

namespace Code.Utils
{
    public class AdaptiveFloatingJoystick : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private RectTransform background;
        [SerializeField] private RectTransform handle;

        [Range(0f,1f), SerializeField] private float backgroundViewportWidthSize = 0.3f;
        [Range(0f,1f), SerializeField] private float handleViewportWidthSize = 0.2f;
        
        private void Awake()
        {
            FitSizeAll();
        }

        private void OnValidate()
        {
            if(background == null || handle == null || container == null)
                return;
            
            FitSizeAll();
        }

        private void FitSizeAll()
        {
            FitSize(background, backgroundViewportWidthSize);
            FitSize(handle, handleViewportWidthSize);
        }

        private void FitSize(RectTransform target, float viewportSize)
        {
            var size = container.rect.width * viewportSize;
            target.sizeDelta = Vector2.one * size;
        }
    }
}