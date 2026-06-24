using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class TogglesView : CodeBehindView
    {
        public TogglesView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoToggle, OnToggled);
            OnValueChanged(DemoRadio, OnRadioChanged);
            OnValueChanged(DemoRadioGroup, OnRadioGroupChanged);
            OnValueChanged(DemoFoldout, OnFoldToggled);
        }

        private static void OnToggled(ChangeEvent<bool> evt) => Debug.Log(evt.newValue);
        private static void OnRadioChanged(ChangeEvent<bool> evt) => Debug.Log(evt.newValue);
        private static void OnRadioGroupChanged(ChangeEvent<int> evt) => Debug.Log(evt.newValue);
        private static void OnFoldToggled(ChangeEvent<bool> evt) => Debug.Log(evt.newValue);
    }
}
