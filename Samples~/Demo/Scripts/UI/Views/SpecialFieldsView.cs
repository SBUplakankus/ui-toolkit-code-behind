using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class SpecialFieldsView : CodeBehindView
    {
        public SpecialFieldsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoHash128, OnHashChanged);
            DemoProgress.value = 75;
        }

        private static void OnHashChanged(ChangeEvent<Hash128> evt) => Debug.Log(evt.newValue);
    }
}
