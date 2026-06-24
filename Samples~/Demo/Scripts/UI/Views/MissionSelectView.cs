using Data;
using UI.Enums;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("MISSION SELECT")]
    public sealed partial class MissionSelectView : CodeBehindView
    {
        public MissionSelectView(VisualTreeAsset template) : base(template) { }

        private static int CompletedMissions => SaveDataManager.CurrentSave.missionsCompleted;

        protected override void Bind()
        {
            OnClick(SemperfiBtn, HandleSemperFiClicked);
            OnClick(LittleResistanceBtn, HandleLittleResistanceClicked);
            OnClick(HardLandingBtn, HandleHardLandingClicked);
            OnClick(VendettaBtn, HandleVendettaClicked);
            OnClick(TheirLandTheirBloodBtn, HandleTheirLandTheirBloodClicked);
            OnClick(BurnEmOutBtn, HandleBurnEmOutClicked);
            OnClick(RelentlessBtn, HandleRelentlessClicked);
            OnClick(BloodAndIronBtn, HandleBloodAndIronClicked);
            OnClick(RingOfSteelBtn, HandleRingOfSteelClicked);
            OnClick(EvictionBtn, HandleEvictionClicked);
            OnClick(BlackCatsBtn, HandleBlackCatsClicked);
            OnClick(BlowtorchAndCorkscrewBtn, HandleBlowtorchAndCorkscrewClicked);
            OnClick(BreakingPointBtn, HandleBreakingPointClicked);
            OnClick(HeartOfTheReichBtn, HandleHeartOfTheReichClicked);
            OnClick(DownfallBtn, HandleDownfallClicked);

            OnHover(SemperfiBtn, OnSemperFiHover);
            OnHover(LittleResistanceBtn, OnLittleResistanceHover);
            OnHover(HardLandingBtn, OnHardLandingHover);
            OnHover(VendettaBtn, OnVendettaHover);
            OnHover(TheirLandTheirBloodBtn, OnTheirLandTheirBloodHover);
            OnHover(BurnEmOutBtn, OnBurnEmOutHover);
            OnHover(RelentlessBtn, OnRelentlessHover);
            OnHover(BloodAndIronBtn, OnBloodAndIronHover);
            OnHover(RingOfSteelBtn, OnRingOfSteelHover);
            OnHover(EvictionBtn, OnEvictionHover);
            OnHover(BlackCatsBtn, OnBlackCatsHover);
            OnHover(BlowtorchAndCorkscrewBtn, OnBlowtorchAndCorkscrewHover);
            OnHover(BreakingPointBtn, OnBreakingPointHover);
            OnHover(HeartOfTheReichBtn, OnHeartOfTheReichHover);
            OnHover(DownfallBtn, OnDownfallHover);

            SetMissionAvailability();
            DisplayMission(Missions.SemperFi);
        }

        private void DisplayMission(Missions mission)
        {
            if (!IsMissionEnabled(mission)) return;

            MissionHeader.text = UIResources.MissionTitles[mission];
            MissionDescription.text = UIResources.MissionDescriptions[mission];
            MissionThumbnail.image = UIResources.MissionThumbnails[mission];
        }

        private bool IsMissionEnabled(Missions mission) => mission switch
        {
            Missions.SemperFi => SemperfiBtn.enabledSelf,
            Missions.LittleResistance => LittleResistanceBtn.enabledSelf,
            Missions.HardLanding => HardLandingBtn.enabledSelf,
            Missions.Vendetta => VendettaBtn.enabledSelf,
            Missions.TheirLandTheirBlood => TheirLandTheirBloodBtn.enabledSelf,
            Missions.BurnEmOut => BurnEmOutBtn.enabledSelf,
            Missions.Relentless => RelentlessBtn.enabledSelf,
            Missions.BloodAndIron => BloodAndIronBtn.enabledSelf,
            Missions.RingOfSteel => RingOfSteelBtn.enabledSelf,
            Missions.Eviction => EvictionBtn.enabledSelf,
            Missions.BlackCats => BlackCatsBtn.enabledSelf,
            Missions.BlowtorchAndCorkscrew => BlowtorchAndCorkscrewBtn.enabledSelf,
            Missions.BreakingPoint => BreakingPointBtn.enabledSelf,
            Missions.HeartOfTheReich => HeartOfTheReichBtn.enabledSelf,
            Missions.Downfall => DownfallBtn.enabledSelf,
            _ => false
        };

        private void OnSemperFiHover(PointerEnterEvent _) => DisplayMission(Missions.SemperFi);
        private void OnLittleResistanceHover(PointerEnterEvent _) => DisplayMission(Missions.LittleResistance);
        private void OnHardLandingHover(PointerEnterEvent _) => DisplayMission(Missions.HardLanding);
        private void OnVendettaHover(PointerEnterEvent _) => DisplayMission(Missions.Vendetta);
        private void OnTheirLandTheirBloodHover(PointerEnterEvent _) => DisplayMission(Missions.TheirLandTheirBlood);
        private void OnBurnEmOutHover(PointerEnterEvent _) => DisplayMission(Missions.BurnEmOut);
        private void OnRelentlessHover(PointerEnterEvent _) => DisplayMission(Missions.Relentless);
        private void OnBloodAndIronHover(PointerEnterEvent _) => DisplayMission(Missions.BloodAndIron);
        private void OnRingOfSteelHover(PointerEnterEvent _) => DisplayMission(Missions.RingOfSteel);
        private void OnEvictionHover(PointerEnterEvent _) => DisplayMission(Missions.Eviction);
        private void OnBlackCatsHover(PointerEnterEvent _) => DisplayMission(Missions.BlackCats);
        private void OnBlowtorchAndCorkscrewHover(PointerEnterEvent _) => DisplayMission(Missions.BlowtorchAndCorkscrew);
        private void OnBreakingPointHover(PointerEnterEvent _) => DisplayMission(Missions.BreakingPoint);
        private void OnHeartOfTheReichHover(PointerEnterEvent _) => DisplayMission(Missions.HeartOfTheReich);
        private void OnDownfallHover(PointerEnterEvent _) => DisplayMission(Missions.Downfall);

        private void HandleSemperFiClicked() => LoadMission(Missions.SemperFi);
        private void HandleLittleResistanceClicked() => LoadMission(Missions.LittleResistance);
        private void HandleHardLandingClicked() => LoadMission(Missions.HardLanding);
        private void HandleVendettaClicked() => LoadMission(Missions.Vendetta);
        private void HandleTheirLandTheirBloodClicked() => LoadMission(Missions.TheirLandTheirBlood);
        private void HandleBurnEmOutClicked() => LoadMission(Missions.BurnEmOut);
        private void HandleRelentlessClicked() => LoadMission(Missions.Relentless);
        private void HandleBloodAndIronClicked() => LoadMission(Missions.BloodAndIron);
        private void HandleRingOfSteelClicked() => LoadMission(Missions.RingOfSteel);
        private void HandleEvictionClicked() => LoadMission(Missions.Eviction);
        private void HandleBlackCatsClicked() => LoadMission(Missions.BlackCats);
        private void HandleBlowtorchAndCorkscrewClicked() => LoadMission(Missions.BlowtorchAndCorkscrew);
        private void HandleBreakingPointClicked() => LoadMission(Missions.BreakingPoint);
        private void HandleHeartOfTheReichClicked() => LoadMission(Missions.HeartOfTheReich);
        private void HandleDownfallClicked() => LoadMission(Missions.Downfall);

        private static void LoadMission(Missions mission) => Debug.Log("Loading mission " + mission);

        private void SetMissionAvailability()
        {
            var completed = CompletedMissions;
            SemperfiBtn.SetEnabled(true);
            LittleResistanceBtn.SetEnabled(1 <= completed);
            HardLandingBtn.SetEnabled(2 <= completed);
            VendettaBtn.SetEnabled(3 <= completed);
            TheirLandTheirBloodBtn.SetEnabled(4 <= completed);
            BurnEmOutBtn.SetEnabled(5 <= completed);
            RelentlessBtn.SetEnabled(6 <= completed);
            BloodAndIronBtn.SetEnabled(7 <= completed);
            RingOfSteelBtn.SetEnabled(8 <= completed);
            EvictionBtn.SetEnabled(9 <= completed);
            BlackCatsBtn.SetEnabled(10 <= completed);
            BlowtorchAndCorkscrewBtn.SetEnabled(11 <= completed);
            BreakingPointBtn.SetEnabled(12 <= completed);
            HeartOfTheReichBtn.SetEnabled(13 <= completed);
            DownfallBtn.SetEnabled(14 <= completed);
        }
    }
}
