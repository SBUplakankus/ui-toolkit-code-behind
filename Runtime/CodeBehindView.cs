using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace UITK.CodeBehind
{
    public abstract partial class CodeBehindView : IDisposable
    {
        public VisualElement Root { get; private set; }

        private readonly List<Action> _cleanup = new();
        private bool _disposed;

        protected CodeBehindView(VisualTreeAsset template)
        {
            Root = template.CloneTree();
            Root.style.flexGrow = 1;
        }

        public void Activate()
        {
            OnActivate();
            Bind();
        }

        public void Deactivate()
        {
            UnBind();
            foreach (var c in _cleanup)
                c();
            _cleanup.Clear();
        }

        protected virtual void OnActivate() { }
        protected virtual void Bind() { }
        protected virtual void UnBind() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Deactivate();
                Root.RemoveFromHierarchy();
                Root = null;
            }
            _disposed = true;
        }
    }
}
