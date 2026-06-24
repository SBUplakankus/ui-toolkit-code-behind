using System;
using UnityEngine;

namespace UITK.CodeBehind
{
    public class UIRouter
    {
        private static UIRouter _instance;
        public static UIRouter Instance => _instance ??= new();

        private UILayer _screenLayer;
        private UILayer _modalLayer;
        private bool _ready;

        public event Action<CodeBehindView> ScreenChanged;
        public event Action<CodeBehindView> ModalOpened;
        public event Action ModalClosed;
        public event Action ModalsCleared;

        public void Init(UILayer screenLayer, UILayer modalLayer)
        {
            _screenLayer = screenLayer;
            _modalLayer = modalLayer;
            _ready = true;
        }

        public void NavigateTo<TView>() where TView : CodeBehindView
        {
            if (!EnsureReady("NavigateTo")) return;
            var view = ViewFactory.Create<TView>();
            if (view == null) return;
            _screenLayer.Push(view);
            ScreenChanged?.Invoke(view);
        }

        public void OpenModal<TModal>() where TModal : CodeBehindView
        {
            if (!EnsureReady("OpenModal")) return;
            var view = ViewFactory.Create<TModal>();
            if (view == null) return;
            _modalLayer.Push(view);
            ModalOpened?.Invoke(view);
        }

        public void Back()
        {
            if (!EnsureReady("Back")) return;
            if (_screenLayer.IsEmpty) return;
            _screenLayer.Pop();
            ScreenChanged?.Invoke(_screenLayer.Current);
        }

        public void CloseModal()
        {
            if (!EnsureReady("CloseModal")) return;
            _modalLayer.Pop();
            ModalClosed?.Invoke();
        }

        public void ClearModals()
        {
            if (!EnsureReady("ClearModals")) return;
            _modalLayer.Clear();
            ModalsCleared?.Invoke();
        }

        private bool EnsureReady(string method)
        {
            if (_ready) return true;
            Debug.LogError($"UIRouter.{method}: not initialized — call Init() first");
            return false;
        }
    }
}
