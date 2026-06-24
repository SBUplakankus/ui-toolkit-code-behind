using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class DisplayView : CodeBehindView
    {
        public DisplayView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            DemoLbl.text = "Updated in Bind()";
        }
    }
}
