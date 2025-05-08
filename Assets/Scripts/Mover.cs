using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace DSIFin
{
    public class Mover : PointerManipulator
    {
        bool _active;
        private Vector3 m_start;
        private int _pointer;
        private Vector2 m_size;
        public Mover()
        {
            _pointer = -1;
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
            _active = false;
        }
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(OnPointerDown);
            target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }
        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }
        protected void OnPointerDown(PointerDownEvent e)
        {
            if (_active)
            {
                e.StopImmediatePropagation();
                return;
            }
            if (CanStartManipulation(e))
            {
                m_start = e.localPosition;
                _pointer = e.pointerId;
                Debug.Log("1");
                _active = true;
                target.CapturePointer(_pointer);
                e.StopPropagation();
            }
        }
        protected void OnPointerMove(PointerMoveEvent e)
        {
            if (!_active || !target.HasPointerCapture(_pointer))
            {
                return;
            }
            Vector2 diff = e.localPosition - m_start;

            target.style.top = target.layout.y + diff.y;
            target.style.left = target.layout.x + diff.x;

            Debug.Log("2");
            e.StopPropagation();
        }
        protected void OnPointerUp(PointerUpEvent e)
        {
            if (!CanStartManipulation(e) || !_active || !target.HasPointerCapture(_pointer)) return;

            _active = false;
            target.ReleasePointer(_pointer); // ¡Esto es lo correcto!
            target.style.cursor = StyleKeyword.Null;
            Debug.Log("3");
            e.StopPropagation();
        }


    }
}
