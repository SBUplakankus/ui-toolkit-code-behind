using System.Reflection;
using UI.Records;
using UITK.CodeBehind;

namespace UI.Core
{
    public class ModalController
    {
        private readonly ModalLayoutElements _elements;

        public ModalController(ModalLayoutElements elements)
        {
            _elements = elements;
        }

        public void Show()
        {
            _elements.ModalContainer.visible = true;
            _elements.ModalContainer.pickingMode = UnityEngine.UIElements.PickingMode.Position;
        }

        public void Hide()
        {
            _elements.ModalContainer.visible = false;
            _elements.ModalContainer.pickingMode = UnityEngine.UIElements.PickingMode.Ignore;
        }

        public void SetTitle(CodeBehindView view)
        {
            var attr = view.GetType().GetCustomAttribute<HeaderNameAttribute>();
            _elements.Header.text = attr != null ? attr.HeaderName : "MAIN MENU";
        }
    }
}
