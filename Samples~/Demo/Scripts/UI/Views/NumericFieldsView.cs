using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class NumericFieldsView : CodeBehindView
    {
        public NumericFieldsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoInt, OnIntChanged);
            OnValueChanged(DemoLong, OnLongChanged);
            OnValueChanged(DemoFloat, OnFloatChanged);
            OnValueChanged(DemoDouble, OnDoubleChanged);
            OnValueChanged(DemoUint, OnUintChanged);
            OnValueChanged(DemoUlong, OnUlongChanged);
        }

        private static void OnIntChanged(ChangeEvent<int> evt) => Debug.Log(evt.newValue);
        private static void OnLongChanged(ChangeEvent<long> evt) => Debug.Log(evt.newValue);
        private static void OnFloatChanged(ChangeEvent<float> evt) => Debug.Log(evt.newValue);
        private static void OnDoubleChanged(ChangeEvent<double> evt) => Debug.Log(evt.newValue);
        private static void OnUintChanged(ChangeEvent<uint> evt) => Debug.Log(evt.newValue);
        private static void OnUlongChanged(ChangeEvent<ulong> evt) => Debug.Log(evt.newValue);
    }
}
