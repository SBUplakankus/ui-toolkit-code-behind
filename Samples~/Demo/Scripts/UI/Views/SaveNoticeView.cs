using Data;
using UITK.CodeBehind;
using UnityEngine.UIElements;

namespace UI.Views
{
    [HeaderName("Notice")]
    public sealed partial class SaveNoticeView : CodeBehindView
    {
        public SaveNoticeView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(OkBtn, HandleOkClicked);
        }

        private static void HandleOkClicked()
        {
            var save = SaveDataManager.CurrentSave;
            SaveDataManager.Save(save);
            UIRouter.Instance.CloseModal();
        }
    }
}
