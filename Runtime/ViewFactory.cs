using UnityEngine;
using UnityEngine.UIElements;

namespace UITK.CodeBehind
{
    public static class ViewFactory
    {
        public static TView Create<TView>() where TView : CodeBehindView
        {
            var name = typeof(TView).Name;
            var template = Resources.Load<VisualTreeAsset>($"Views/{name}");
            if (!template)
            {
                Debug.LogError($"ViewFactory: missing Resources/Views/{name}.uxml");
                return null;
            }
            return (TView)System.Activator.CreateInstance(typeof(TView), new object[] { template });
        }
    }
}
