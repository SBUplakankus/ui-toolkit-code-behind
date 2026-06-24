using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class TextFieldView : CodeBehindView
    {
        public TextFieldView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoText, OnTextChanged);
            OnValueChanged(DemoDropdown, OnDropdownChanged);
            OnValueChanged(DemoEnum, OnEnumChanged);
        }

        private static void OnTextChanged(ChangeEvent<string> evt) => Debug.Log(evt.newValue);
        private static void OnDropdownChanged(ChangeEvent<string> evt) => Debug.Log(evt.newValue);
        private static void OnEnumChanged(ChangeEvent<System.Enum> evt) => Debug.Log(evt.newValue);
    }
}
