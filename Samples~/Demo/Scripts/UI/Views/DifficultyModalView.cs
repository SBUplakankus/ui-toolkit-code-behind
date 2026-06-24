using Data;
using UI.Enums;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("Difficulty")]
    public sealed partial class DifficultyModalView : CodeBehindView
    {
        public DifficultyModalView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(RecruitBtn, HandleRecruitClicked);
            OnClick(RegularBtn, HandleRegularClicked);
            OnClick(HardenedBtn, HandleHardenedClicked);
            OnClick(VeteranBtn, HandleVeteranClicked);

            OnHover(RecruitBtn, OnRecruitEnter);
            OnHover(RegularBtn, OnRegularEnter);
            OnHover(HardenedBtn, OnHardenedEnter);
            OnHover(VeteranBtn, OnVeteranEnter);
        }

        private static void DifficultySelected(Difficulty difficulty)
        {
            SaveDataManager.Delete();
            var save = SaveDataManager.CurrentSave;
            save.campaignStarted = true;
            save.missionsCompleted = 0;
            SaveDataManager.Save(save);
            Debug.Log("Difficulty set to: " + difficulty);
            UIRouter.Instance.ClearModals();
            UIRouter.Instance.Back();
        }

        private void SetPreview(Difficulty difficulty)
        {
            DifficultyIcon.vectorImage = UIResources.DifficultyIcons[difficulty];
            DifficultyDescription.text = UIResources.DifficultyDescriptions[difficulty];
        }

        private void OnRecruitEnter(PointerEnterEvent _) => SetPreview(Difficulty.Recruit);
        private void OnRegularEnter(PointerEnterEvent _) => SetPreview(Difficulty.Regular);
        private void OnHardenedEnter(PointerEnterEvent _) => SetPreview(Difficulty.Hardened);
        private void OnVeteranEnter(PointerEnterEvent _) => SetPreview(Difficulty.Veteran);

        private void HandleRecruitClicked() => DifficultySelected(Difficulty.Recruit);
        private void HandleRegularClicked() => DifficultySelected(Difficulty.Regular);
        private void HandleHardenedClicked() => DifficultySelected(Difficulty.Hardened);
        private void HandleVeteranClicked() => DifficultySelected(Difficulty.Veteran);
    }
}
