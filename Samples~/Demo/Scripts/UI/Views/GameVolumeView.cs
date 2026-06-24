using Data;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("GAME VOLUME")]
    public sealed partial class GameVolumeView : CodeBehindView
    {
        private PlayerSaveData _save;

        public GameVolumeView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            _save = SaveDataManager.CurrentSave;

            VoiceSlider.value = _save.settings.voiceVolume;
            MusicSlider.value = _save.settings.musicVolume;
            SfxSlider.value = _save.settings.sfxVolume;
            CinematicsSlider.value = _save.settings.cinematicsVolume;
            MasterSlider.value = _save.settings.masterVolume;
            VoipSlider.value = _save.settings.voipVolume;

            OnValueChanged(VoiceSlider, OnVoiceChanged);
            OnValueChanged(MusicSlider, OnMusicChanged);
            OnValueChanged(SfxSlider, OnSfxChanged);
            OnValueChanged(CinematicsSlider, OnCinematicsChanged);
            OnValueChanged(MasterSlider, OnMasterChanged);
            OnValueChanged(VoipSlider, OnVoipChanged);

            OnBlur(VoiceSlider, SaveVolumeSettings);
            OnBlur(MusicSlider, SaveVolumeSettings);
            OnBlur(SfxSlider, SaveVolumeSettings);
            OnBlur(CinematicsSlider, SaveVolumeSettings);
            OnBlur(MasterSlider, SaveVolumeSettings);
            OnBlur(VoipSlider, SaveVolumeSettings);

            OnClick(VoiceBtn, HandleVoiceClicked);
            OnClick(MusicBtn, HandleMusicClicked);
            OnClick(SfxBtn, HandleSfxClicked);
            OnClick(CinematicsBtn, HandleCinematicsClicked);
            OnClick(MasterBtn, HandleMasterClicked);
            OnClick(VoipBtn, HandleVoipClicked);
        }

        private void SaveVolumeSettings(BlurEvent _) => SaveDataManager.Save(_save);

        private void OnVoiceChanged(ChangeEvent<float> evt) => _save.settings.voiceVolume = evt.newValue;
        private void OnMusicChanged(ChangeEvent<float> evt) => _save.settings.musicVolume = evt.newValue;
        private void OnSfxChanged(ChangeEvent<float> evt) => _save.settings.sfxVolume = evt.newValue;
        private void OnCinematicsChanged(ChangeEvent<float> evt) => _save.settings.cinematicsVolume = evt.newValue;
        private void OnMasterChanged(ChangeEvent<float> evt) => _save.settings.masterVolume = evt.newValue;
        private void OnVoipChanged(ChangeEvent<float> evt) => _save.settings.voipVolume = evt.newValue;

        private static void HandleVoiceClicked() => Debug.Log("Voice clicked");
        private static void HandleMusicClicked() => Debug.Log("Music clicked");
        private static void HandleSfxClicked() => Debug.Log("SFX clicked");
        private static void HandleCinematicsClicked() => Debug.Log("Cinematics clicked");
        private static void HandleMasterClicked() => Debug.Log("Master clicked");
        private static void HandleVoipClicked() => Debug.Log("Voip clicked");
    }
}
