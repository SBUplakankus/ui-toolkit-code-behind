using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class VectorFieldsView : CodeBehindView
    {
        public VectorFieldsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnValueChanged(DemoVec2, OnVec2Changed);
            OnValueChanged(DemoVec3, OnVec3Changed);
            OnValueChanged(DemoVec4, OnVec4Changed);
            OnValueChanged(DemoVec2int, OnVec2IntChanged);
            OnValueChanged(DemoVec3int, OnVec3IntChanged);
        }

        private static void OnVec2Changed(ChangeEvent<Vector2> evt) => Debug.Log(evt.newValue);
        private static void OnVec3Changed(ChangeEvent<Vector3> evt) => Debug.Log(evt.newValue);
        private static void OnVec4Changed(ChangeEvent<Vector4> evt) => Debug.Log(evt.newValue);
        private static void OnVec2IntChanged(ChangeEvent<Vector2Int> evt) => Debug.Log(evt.newValue);
        private static void OnVec3IntChanged(ChangeEvent<Vector3Int> evt) => Debug.Log(evt.newValue);
    }
}
