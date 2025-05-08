using UnityEngine;
using UnityEngine.UIElements;

namespace DSIFin
{
    public class Rotator : MouseManipulator
    {
        private float currentRotation = 0f;

        public Rotator()
        {
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<ClickEvent>(OnClick);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<ClickEvent>(OnClick);
        }

        private void OnClick(ClickEvent evt)
        {
            currentRotation -= 90f;
            target.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }
}
