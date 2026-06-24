using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("New Game")]
    public sealed partial class NewGameModalView : CodeBehindView
    {
        public NewGameModalView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(YesBtn, HandleYesClicked);
            OnClick(NoBtn, HandleNoClicked);
        }

        private static void HandleYesClicked() => UIRouter.Instance.OpenModal<ContentWarningModalView>();
        private static void HandleNoClicked() => UIRouter.Instance.CloseModal();
    }
}
