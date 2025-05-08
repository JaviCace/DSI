using UnityEngine;
using UnityEngine.UIElements;

namespace DSIFin
{
    public class Pointer : PointerManipulator
    {
        private static VisualElement _currentSelected;

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        private void OnPointerEnter(PointerEnterEvent e)
        {
            // Quita el borde del elemento anterior
            if (_currentSelected != null && _currentSelected != target)
            {
                RemoveWhiteBorder(_currentSelected);
            }

            // Añade borde blanco al actual
            AddWhiteBorder(target);
            _currentSelected = target;
        }

        private void OnPointerLeave(PointerLeaveEvent e)
        {
            // Si deseas quitar el borde al salir, descomenta esto:
            // RemoveWhiteBorder(target);
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
