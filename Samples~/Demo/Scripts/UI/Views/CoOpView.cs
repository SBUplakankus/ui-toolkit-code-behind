using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("COOPERATIVE CAMPAIGN")]
    public sealed partial class CoOpView : CodeBehindView
    {
        public CoOpView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(OnlineBtn, HandleOnlineClicked);
            OnClick(SplitscreenBtn, HandleSplitScreenClicked);
            OnClick(LanBtn, HandleLanClicked);
        }

        private static void HandleOnlineClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleSplitScreenClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleLanClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
    }
}
