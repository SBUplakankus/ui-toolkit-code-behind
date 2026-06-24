using System;
using UnityEngine.UIElements;

namespace UITK.CodeBehind
{
    public abstract partial class CodeBehindView
    {
        // --- Click ---

        protected void OnClick(Button button, Action handler)
        {
            button.clicked += handler;
            _cleanup.Add(() => button.clicked -= handler);
        }

        protected void OnClick(VisualElement element, EventCallback<ClickEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        // --- Pointer ---

        protected void OnHover(VisualElement element, EventCallback<PointerEnterEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnPointerLeave(VisualElement element, EventCallback<PointerLeaveEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnPointerDown(VisualElement element, EventCallback<PointerDownEvent> handler)
        {
            element.RegisterCallback(handler, TrickleDown.TrickleDown);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnPointerUp(VisualElement element, EventCallback<PointerUpEvent> handler)
        {
            element.RegisterCallback(handler, TrickleDown.TrickleDown);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnPointerMove(VisualElement element, EventCallback<PointerMoveEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        // --- Value (BaseField) ---

        protected void OnValueChanged<T>(BaseField<T> field, EventCallback<ChangeEvent<T>> handler)
        {
            field.RegisterValueChangedCallback(handler);
            _cleanup.Add(() => field.UnregisterValueChangedCallback(handler));
        }

        // --- Value (non-BaseField) ---

        protected void OnValueChanged(Foldout foldout, EventCallback<ChangeEvent<bool>> handler)
        {
            foldout.RegisterCallback(handler);
            _cleanup.Add(() => foldout.UnregisterCallback(handler));
        }

        protected void OnValueChanged(Scroller scroller, EventCallback<ChangeEvent<float>> handler)
        {
            scroller.RegisterCallback(handler);
            _cleanup.Add(() => scroller.UnregisterCallback(handler));
        }

        // --- Focus ---

        protected void OnBlur(VisualElement element, EventCallback<BlurEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnFocus(VisualElement element, EventCallback<FocusEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        // --- Keyboard ---

        protected void OnKeyDown(VisualElement element, EventCallback<KeyDownEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        protected void OnKeyUp(VisualElement element, EventCallback<KeyUpEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }

        // --- Layout ---

        protected void OnGeometryChanged(VisualElement element, EventCallback<GeometryChangedEvent> handler)
        {
            element.RegisterCallback(handler);
            _cleanup.Add(() => element.UnregisterCallback(handler));
        }
    }
}
