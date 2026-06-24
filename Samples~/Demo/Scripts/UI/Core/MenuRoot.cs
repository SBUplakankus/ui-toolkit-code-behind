using Data;
using UI.Factories;
using UI.Records;
using UI.Views;
using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Core
{
    [RequireComponent(typeof(UIDocument))]
    public class MenuRoot : MonoBehaviour
    {
        private ScreenLayoutElements _screenElements;
        private ModalLayoutElements _modalElements;
        private UILayer _screenLayer;
        private UILayer _modalLayer;
        private ChromeController _chrome;
        private ModalController _modal;
        private CodeBehindView _mainMenu;

        private void Awake()
        {
            SaveDataManager.Delete();

            var root = GetComponent<UIDocument>().rootVisualElement;

            _screenElements = LayoutFactory.GetScreenLayout(root);
            _modalElements = LayoutFactory.GetModalLayout(root);

            _screenLayer = new UILayer(_screenElements.ScreenViewContainer);
            _modalLayer = new UILayer(_modalElements.ModalViewContainer);
            _chrome = new ChromeController(_screenElements);
            _modal = new ModalController(_modalElements);

            _chrome.HideBackButton();
            _chrome.SetUsername(SaveDataManager.CurrentSave.username);
            _chrome.SetVersion(Application.version);
            _modal.Hide();

            _chrome.BindBackButton(OnBackClicked);

            var router = UIRouter.Instance;
            router.Init(_screenLayer, _modalLayer);
            router.ScreenChanged += OnScreenChanged;
            router.ModalOpened += OnModalOpened;
            router.ModalClosed += OnModalClosed;
            router.ModalsCleared += OnModalsCleared;

            _mainMenu = ViewFactory.Create<MainMenuView>();

            if (_mainMenu != null)
                _screenLayer.Push(_mainMenu);
        }

        private void Start()
        {
            if (!SaveDataManager.SaveFileExists)
                UIRouter.Instance.OpenModal<SaveNoticeView>();
        }

        private void OnDestroy()
        {
            _chrome.UnbindBackButton(OnBackClicked);
            var router = UIRouter.Instance;
            router.ScreenChanged -= OnScreenChanged;
            router.ModalOpened -= OnModalOpened;
            router.ModalClosed -= OnModalClosed;
            router.ModalsCleared -= OnModalsCleared;
            _screenLayer?.Clear();
            _modalLayer?.Clear();
        }

        private static void OnBackClicked() => UIRouter.Instance.Back();

        private void OnScreenChanged(CodeBehindView view)
        {
            _chrome.SetTitle(view);
            if (_screenLayer.IsEmpty)
                _chrome.HideBackButton();
            else
                _chrome.ShowBackButton();
        }

        private void OnModalOpened(CodeBehindView view)
        {
            _modal.Show();
            _modal.SetTitle(view);
        }

        private void OnModalClosed()
        {
            _modal.Hide();
        }

        private void OnModalsCleared()
        {
            _modal.Hide();
        }
    }
}
