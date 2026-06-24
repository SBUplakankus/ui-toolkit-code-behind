using System.IO;
using UnityEditor;
using UnityEngine;

namespace UITK.CodeBehind.Editor
{
    public static class ViewScaffolder
    {
        public static void CreateView(string viewName)
        {
            if (string.IsNullOrWhiteSpace(viewName)) return;
            viewName = viewName.Trim();
            if (!viewName.EndsWith("View"))
                viewName += "View";

            var viewsDir = "Assets/Resources/Views";
            var scriptsDir = "Assets/Scripts/UI/Views";
            Directory.CreateDirectory(viewsDir);
            Directory.CreateDirectory(scriptsDir);

            var uxmlPath = $"{viewsDir}/{viewName}.uxml";
            var csPath = $"{scriptsDir}/{viewName}.cs";

            if (File.Exists(uxmlPath) || File.Exists(csPath))
            {
                Debug.LogWarning($"ViewScaffolder: {viewName} already exists — skipping");
                return;
            }

            var uxml = $@"<ui:UXML xmlns:ui=""UnityEngine.UIElements"" xmlns:uie=""UnityEditor.UIElements"">
    <Style src=""project://database/Assets/UI Toolkit/Styles/core.uss"" />
    <Style src=""project://database/Assets/UI Toolkit/Styles/screens.uss"" />
    <ui:VisualElement name=""{ToKebabCase(viewName)}"" class=""view-root"" />
</ui:UXML>";

            var cs = $@"using UITK.CodeBehind;
using UnityEngine.UIElements;

namespace {CodeBehindGenerator.ViewsNamespace}
{{
    public sealed partial class {viewName} : CodeBehindView
    {{
        public {viewName}(VisualTreeAsset template) : base(template) {{ }}

        // TODO: add [HeaderName(""TITLE"")] above the class if this view has a chrome title
        // TODO: add behavior methods here
        // TODO: override Bind() for custom logic after generated wiring
    }}
}}
";

            File.WriteAllText(uxmlPath, uxml);
            File.WriteAllText(csPath, cs);

            AssetDatabase.ImportAsset(uxmlPath);
            AssetDatabase.ImportAsset(csPath);
            CodeBehindGenerator.GenerateAll();

            Debug.Log($"ViewScaffolder: created {viewName} (UXML + .cs + generated files)");
        }

        private static string ToKebabCase(string name)
        {
            if (name.EndsWith("View"))
                name = name.Substring(0, name.Length - 4);
            var result = "";
            for (var i = 0; i < name.Length; i++)
            {
                if (i > 0 && char.IsUpper(name[i]))
                    result += "-";
                result += char.ToLowerInvariant(name[i]);
            }
            return result;
        }
    }
}
