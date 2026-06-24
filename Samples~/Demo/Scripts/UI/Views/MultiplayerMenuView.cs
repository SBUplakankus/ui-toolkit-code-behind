using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("MULTIPLAYER")]
    public sealed partial class MultiplayerMenuView : CodeBehindView
    {
        public MultiplayerMenuView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(OnlineBtn, HandleOnlineClicked);
            OnClick(SplitscreenBtn, HandleSplitScreenClicked);
            OnClick(LanpartyBtn, HandleLanPartyClicked);
            OnClick(OptionsBtn, HandleOptionsClicked);

            MotdContent.text = UIResources.MessagesOfTheDay.Random();
        }

        private static void HandleOnlineClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleSplitScreenClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleLanPartyClicked() => UIRouter.Instance.OpenModal<NoConnectionModalView>();
        private static void HandleOptionsClicked() => UIRouter.Instance.NavigateTo<GameOptionsView>();
    }
}
