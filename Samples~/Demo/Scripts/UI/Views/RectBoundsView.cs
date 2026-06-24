using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class RectBoundsView : CodeBehindView
    {
        public RectBoundsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoRect, OnRectChanged);
            OnValueChanged(DemoRectint, OnRectIntChanged);
            OnValueChanged(DemoBounds, OnBoundsChanged);
            OnValueChanged(DemoBoundsint, OnBoundsIntChanged);
        }

        private static void OnRectChanged(ChangeEvent<Rect> evt) => Debug.Log(evt.newValue);
        private static void OnRectIntChanged(ChangeEvent<RectInt> evt) => Debug.Log(evt.newValue);
        private static void OnBoundsChanged(ChangeEvent<Bounds> evt) => Debug.Log(evt.newValue);
        private static void OnBoundsIntChanged(ChangeEvent<BoundsInt> evt) => Debug.Log(evt.newValue);
    }
}
