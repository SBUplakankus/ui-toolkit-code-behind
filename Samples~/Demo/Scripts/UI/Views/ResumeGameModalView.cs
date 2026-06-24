using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("Resume Game")]
    public sealed partial class ResumeGameModalView : CodeBehindView
    {
        public ResumeGameModalView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(YesBtn, HandleYesClicked);
            OnClick(NoBtn, HandleNoClicked);
        }

        private static void HandleYesClicked() => Debug.Log("Resume Game confirmed");
        private static void HandleNoClicked() => UIRouter.Instance.CloseModal();
    }
}
