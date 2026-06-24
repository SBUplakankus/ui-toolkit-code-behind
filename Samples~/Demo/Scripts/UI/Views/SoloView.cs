using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("SOLO CAMPAIGN")]
    public sealed partial class SoloView : CodeBehindView
    {
        public SoloView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(NewBtn, HandleNewGameClicked);
            OnClick(ResumeBtn, HandleResumeGameClicked);
            OnClick(MissionBtn, HandleMissionSelectClicked);

            if (!SaveDataManager.CurrentSave.campaignStarted)
            {
                ResumeBtn.visible = false;
                MissionBtn.visible = false;
            }
        }

        private static void HandleNewGameClicked() => UIRouter.Instance.OpenModal<NewGameModalView>();
        private static void HandleResumeGameClicked() => UIRouter.Instance.OpenModal<ResumeGameModalView>();
        private static void HandleMissionSelectClicked() => UIRouter.Instance.NavigateTo<MissionSelectView>();
    }
}
