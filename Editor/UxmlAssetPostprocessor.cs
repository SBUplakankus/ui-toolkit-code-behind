using UnityEditor;
using UnityEngine;

namespace UITK.CodeBehind.Editor
{
    public class UxmlAssetPostprocessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (var path in importedAssets)
            {
                if (path.StartsWith("Assets/Resources/Views/") && path.EndsWith(".uxml"))
                {
                    CodeBehindGenerator.GenerateAll();
                    return;
                }
            }

            foreach (var path in deletedAssets)
            {
                if (path.StartsWith("Assets/Resources/Views/") && path.EndsWith(".uxml"))
                {
                    CodeBehindGenerator.GenerateAll();
                    return;
                }
            }

            foreach (var path in movedAssets)
            {
                if (path.StartsWith("Assets/Resources/Views/") && path.EndsWith(".uxml"))
                {
                    CodeBehindGenerator.GenerateAll();
                    return;
                }
            }
        }
    }
}
