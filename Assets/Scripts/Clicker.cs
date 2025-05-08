using UnityEngine;
using UnityEngine.UIElements;
namespace DSIFin 
{
    public class Clicker : MouseManipulator
    {
        private System.Action onClick;

        public Clicker(System.Action onClick)
        {
            this.onClick = onClick;
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseDownEvent>(OnClick);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseDownEvent>(OnClick);
        }

        private void OnClick(MouseDownEvent evt)
        {
            bool hasBorder = target.resolvedStyle.borderLeftWidth > 0;

            if (hasBorder)
            {
                RemoveWhiteBorder(target);
            }
            else
            {
                AddWhiteBorder(target);
            }

            onClick?.Invoke();
        }

        private void AddWhiteBorder(VisualElement element)
        {
            element.style.borderLeftWidth = 2;
            element.style.borderRightWidth = 2;
            element.style.borderTopWidth = 2;
            element.style.borderBottomWidth = 2;

            element.style.borderLeftColor = Color.white;
            element.style.borderRightColor = Color.white;
            element.style.borderTopColor = Color.white;
            element.style.borderBottomColor = Color.white;
        }

        private void RemoveWhiteBorder(VisualElement element)
        {
            element.style.borderLeftWidth = 0;
            element.style.borderRightWidth = 0;
            element.style.borderTopWidth = 0;
            element.style.borderBottomWidth = 0;
        }
    }
}
