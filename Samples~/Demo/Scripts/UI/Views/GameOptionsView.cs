using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("OPTIONS")]
    public sealed partial class GameOptionsView : CodeBehindView
    {
        private PlayerSaveData _save;

        public GameOptionsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            _save = SaveDataManager.CurrentSave;

            LookInversionLbl.text = _save.settings.invertLook;
            StickLayoutLbl.text = _save.settings.stickLayout;
            ButtonLayoutLbl.text = _save.settings.buttonLayout;
            SensitivityLbl.text = _save.settings.sensitivity;
            TargetAssistLbl.text = _save.settings.targetAssist;
            PlayerNameLbl.text = _save.settings.playerName;

            OnClick(LookInversionBtn, HandleLookInversionClicked);
            OnClick(StickLayoutBtn, HandleStickLayoutClicked);
            OnClick(ButtonLayoutBtn, HandleButtonLayoutClicked);
            OnClick(SensitivityBtn, HandleSensitivityClicked);
            OnClick(TargetAssistBtn, HandleTargetAssistClicked);
            OnClick(PlayerNameBtn, HandlePlayerNameClicked);
            OnClick(GameVolumeBtn, HandleGameVolumeClicked);
        }

        private void CycleSetting(ref string field, string[] options, TextElement label)
        {
            var index = System.Array.IndexOf(options, field);
            field = options[(index + 1) % options.Length];
            label.text = field;
            SaveDataManager.Save(_save);
        }

        private void HandleLookInversionClicked()
            => CycleSetting(ref _save.settings.invertLook, UIResources.OptionInversion, LookInversionLbl);
        private void HandleStickLayoutClicked()
            => CycleSetting(ref _save.settings.stickLayout, UIResources.OptionStickLayout, StickLayoutLbl);
        private void HandleButtonLayoutClicked()
            => CycleSetting(ref _save.settings.buttonLayout, UIResources.OptionButtonLayout, ButtonLayoutLbl);
        private void HandleSensitivityClicked()
            => CycleSetting(ref _save.settings.sensitivity, UIResources.OptionSensitivity, SensitivityLbl);
        private void HandleTargetAssistClicked()
            => CycleSetting(ref _save.settings.targetAssist, UIResources.OptionTargetAssist, TargetAssistLbl);
        private static void HandlePlayerNameClicked() { }
        private static void HandleGameVolumeClicked() => UIRouter.Instance.NavigateTo<GameVolumeView>();
    }
}
