using UITK.CodeBehind;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("Content Warning")]
    public sealed partial class ContentWarningModalView : CodeBehindView
    {
        public ContentWarningModalView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(OkBtn, HandleOkClicked);
        }

        private static void HandleOkClicked() => UIRouter.Instance.OpenModal<DifficultyModalView>();
    }
}
