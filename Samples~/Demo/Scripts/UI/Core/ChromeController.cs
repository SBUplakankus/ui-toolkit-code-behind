using System;
using System.Reflection;
using UI.Records;
using UITK.CodeBehind;

namespace UI.Core
{
    public class ChromeController
    {
        private readonly ScreenLayoutElements _elements;

        public ChromeController(ScreenLayoutElements elements)
        {
            _elements = elements;
        }

        public void SetTitle(CodeBehindView view)
        {
            var attr = view.GetType().GetCustomAttribute<HeaderNameAttribute>();
            _elements.Header.text = attr != null ? attr.HeaderName : "MAIN MENU";
        }

        public void SetUsername(string username) => _elements.Username.text = $"Signed In: {username}";
        public void SetVersion(string version) => _elements.GameVersion.text = version;
        public void ShowBackButton() => _elements.BackButton.visible = true;
        public void HideBackButton() => _elements.BackButton.visible = false;
        public void BindBackButton(Action onBack) => _elements.BackButton.clicked += onBack;
        public void UnbindBackButton(Action onBack) => _elements.BackButton.clicked -= onBack;
    }
}
