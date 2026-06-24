using UITK.CodeBehind;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("Notice")]
    public sealed partial class NoConnectionModalView : CodeBehindView
    {
        public NoConnectionModalView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(OkBtn, HandleOkClicked);
        }

        private static void HandleOkClicked() => UIRouter.Instance.CloseModal();
    }
}
