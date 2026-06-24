using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class MainMenuView : CodeBehindView
    {
        public MainMenuView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(SoloBtn, HandleSoloClicked);
            OnClick(CoopBtn, HandleCoOpClicked);
            OnClick(MultiBtn, HandleMultiplayerClicked);
            OnClick(ZombiesBtn, HandleZombiesClicked);
            OnClick(OptionsBtn, HandleOptionsClicked);
            OnClick(CreditsBtn, HandleCreditsClicked);

            MotdContent.text = UIResources.MessagesOfTheDay.Random();
        }

        private static void HandleSoloClicked() => UIRouter.Instance.NavigateTo<SoloView>();
        private static void HandleCoOpClicked() => UIRouter.Instance.NavigateTo<CoOpView>();
        private static void HandleMultiplayerClicked() => UIRouter.Instance.NavigateTo<MultiplayerMenuView>();
        private static void HandleZombiesClicked() => UIRouter.Instance.NavigateTo<ZombiesView>();
        private static void HandleOptionsClicked() => UIRouter.Instance.NavigateTo<GameOptionsView>();
        private static void HandleCreditsClicked() => UIRouter.Instance.NavigateTo<CreditsView>();
    }
}
