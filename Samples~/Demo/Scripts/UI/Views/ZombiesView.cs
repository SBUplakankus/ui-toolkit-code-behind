using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("NAZI ZOMBIES")]
    public sealed partial class ZombiesView : CodeBehindView
    {
        public ZombiesView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(ResumeBtn, HandleResumeClicked);
            OnClick(NewBtn, HandleNewGameClicked);
        }

        private static void HandleResumeClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleNewGameClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
    }
}
