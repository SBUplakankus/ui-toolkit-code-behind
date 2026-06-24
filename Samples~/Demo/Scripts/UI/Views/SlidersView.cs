using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class SlidersView : CodeBehindView
    {
        public SlidersView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoSlider, OnSliderChanged);
            OnValueChanged(DemoSliderint, OnSliderIntChanged);
            OnValueChanged(DemoMinmax, OnMinMaxChanged);
            OnValueChanged(DemoScroller, OnScrolled);
        }

        private static void OnSliderChanged(ChangeEvent<float> evt) => Debug.Log(evt.newValue);
        private static void OnSliderIntChanged(ChangeEvent<int> evt) => Debug.Log(evt.newValue);
        private static void OnMinMaxChanged(ChangeEvent<Vector2> evt) => Debug.Log(evt.newValue);
        private static void OnScrolled(ChangeEvent<float> evt) => Debug.Log(evt.newValue);
    }
}
