using UI.Constants;
using UI.Records;
using UnityEngine.UIElements;

namespace UI.Records
{
    public sealed record ScreenLayoutElements(
        Label Header,
        Label Username,
        Label GameVersion,
        Button BackButton,
        VisualElement ScreenViewContainer
    );

    public sealed record ModalLayoutElements(
        Label Header,
        VisualElement ModalViewContainer,
        VisualElement ModalContainer
    );
}

namespace UI.Factories
{
    public static class LayoutFactory
    {
        public static ScreenLayoutElements GetScreenLayout(VisualElement root)
        {
            return new ScreenLayoutElements(
                Header: root.Q<Label>(LayoutConstants.MenuName),
                Username: root.Q<Label>(LayoutConstants.UsernameLabel),
                GameVersion: root.Q<Label>(LayoutConstants.VersionLabel),
                BackButton: root.Q<Button>(LayoutConstants.BackBtn),
                ScreenViewContainer: root.Q<VisualElement>(LayoutConstants.ScreenViewContainer)
            );
        }

        public static ModalLayoutElements GetModalLayout(VisualElement root)
        {
            return new ModalLayoutElements(
                Header: root.Q<Label>(LayoutConstants.ModalHeader),
                ModalViewContainer: root.Q<VisualElement>(LayoutConstants.ModalViewContainer),
                ModalContainer: root.Q<VisualElement>(LayoutConstants.ModalContainer)
            );
        }
    }
}
