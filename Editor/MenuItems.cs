using UnityEditor;
using UnityEngine;

namespace UITK.CodeBehind.Editor
{
    public static class MenuItems
    {
        [MenuItem("Tools/Code Behind/Regenerate")]
        private static void Regenerate()
        {
            CodeBehindGenerator.GenerateAll();
        }

        [MenuItem("Tools/Code Behind/New View")]
        private static void NewView()
        {
            ViewScaffolder.CreateView("NewView");
            EditorApplication.delayCall += () =>
            {
                var path = "Assets/Scripts/UI/Views/NewViewView.cs";
                if (System.IO.File.Exists(path))
                    UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(path, 0);
            };
        }
    }
}
