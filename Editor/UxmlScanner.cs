using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UITK.CodeBehind.Editor
{
    public class ScannedElement
    {
        public string Name { get; set; }
        public Type ElementType { get; set; }
    }

    public class ScannedView
    {
        public string ClassName { get; set; }
        public string UxmlPath { get; set; }
        public List<ScannedElement> Elements { get; set; } = new();
    }

    public static class UxmlScanner
    {
        private static readonly Dictionary<string, Type> DirectTypes = new()
        {
            ["Button"] = typeof(Button),
            ["Label"] = typeof(Label),
            ["Slider"] = typeof(Slider),
            ["Image"] = typeof(Image),
            ["VisualElement"] = typeof(VisualElement),
            ["ScrollView"] = typeof(ScrollView),
            ["Toggle"] = typeof(Toggle),
            ["TextField"] = typeof(TextField),
            ["MinMaxSlider"] = typeof(MinMaxSlider),
            ["Scroller"] = typeof(Scroller),
            ["ToggleButtonGroup"] = typeof(ToggleButtonGroup),
            ["RadioButtonGroup"] = typeof(RadioButtonGroup),
            ["UnsignedIntegerField"] = typeof(UnsignedIntegerField),
            ["UnsignedLongField"] = typeof(UnsignedLongField),
            ["TabView"] = typeof(TabView),
            ["BoundsField"] = typeof(BoundsField),
            ["RectField"] = typeof(RectField),
            ["BoundsIntField"] = typeof(BoundsIntField),
            ["RectIntField"] = typeof(RectIntField),
            ["Vector3IntField"] = typeof(Vector3IntField),
            ["Vector2IntField"] = typeof(Vector2IntField),
            ["Vector4Field"] = typeof(Vector4Field),
            ["Vector3Field"] = typeof(Vector3Field),
            ["Tab"] = typeof(Tab),
            ["Vector2Field"] = typeof(Vector2Field),
            ["Hash128Field"] = typeof(Hash128Field),
            ["DoubleField"] = typeof(DoubleField),
            ["LongField"] = typeof(LongField),
            ["FloatField"] = typeof(FloatField),
            ["IntegerField"] = typeof(IntegerField),
            ["ProgressBar"] = typeof(ProgressBar),
            ["RadioButton"] = typeof(RadioButton),
            ["EnumField"] = typeof(EnumField),
            ["DropdownField"] = typeof(DropdownField),
            ["SliderInt"] = typeof(SliderInt),
            ["MultiColumnTreeView"] = typeof(MultiColumnTreeView),
            ["MultiColumnListView"] = typeof(MultiColumnListView),
            ["TreeView"] = typeof(TreeView),
            ["ListView"] = typeof(ListView),
            ["Foldout"] = typeof(Foldout),
        };

        private static Dictionary<string, Type> _templateCache;

        public static List<ScannedView> ScanAllViews()
        {
            DiscoverTemplates();

            var results = new List<ScannedView>();
            var guids = AssetDatabase.FindAssets("t:VisualTreeAsset", new[] { "Assets/Resources/Views" });
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var view = ScanView(path);
                if (view != null)
                    results.Add(view);
            }
            return results;
        }

        private static void DiscoverTemplates()
        {
            if (_templateCache != null) return;
            _templateCache = new Dictionary<string, Type>();
            var guids = AssetDatabase.FindAssets("t:VisualTreeAsset", new[] { "Assets/UI Toolkit/Templates" });
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var name = Path.GetFileNameWithoutExtension(path);
                if (!_templateCache.ContainsKey(name))
                    _templateCache[name] = InferTemplateRootType(path);
            }
        }

        private static Type InferTemplateRootType(string templatePath)
        {
            try
            {
                var text = File.ReadAllText(templatePath);
                var doc = XDocument.Parse(text);
                foreach (var kv in DirectTypes)
                {
                    var found = doc.Descendants()
                        .FirstOrDefault(e => e.Name.LocalName == kv.Key);
                    if (found != null)
                        return kv.Value;
                }
            }
            catch { }
            return typeof(VisualElement);
        }

        private static ScannedView ScanView(string uxmlPath)
        {
            try
            {
                var text = File.ReadAllText(uxmlPath);
                var doc = XDocument.Parse(text);
                var className = Path.GetFileNameWithoutExtension(uxmlPath);
                var view = new ScannedView
                {
                    ClassName = className,
                    UxmlPath = uxmlPath,
                };

                foreach (var element in doc.Descendants())
                {
                    // Skip Template and Style declarations — they have a 'src' attribute
                    if (element.Attribute("src") != null)
                        continue;

                    // Skip elements without a name attribute
                    var nameAttr = element.Attribute("name");
                    if (nameAttr == null)
                        continue;

                    var name = nameAttr.Value;

                    // Skip root container — case-insensitive match against class name
                    if (string.Equals(ToPascalCase(name), className, StringComparison.OrdinalIgnoreCase))
                        continue;

                    var type = InferElementType(element);

                    view.Elements.Add(new ScannedElement
                    {
                        Name = name,
                        ElementType = type,
                    });
                }

                return view;
            }
            catch (Exception ex)
            {
                Debug.LogError($"UxmlScanner: failed to scan {uxmlPath} — {ex.Message}");
                return null;
            }
        }

        private static Type InferElementType(XElement element)
        {
            var localName = element.Name.LocalName;

            if (DirectTypes.TryGetValue(localName, out var directType))
                return directType;

            if (localName == "Instance")
            {
                var templateAttr = element.Attribute("template");
                if (templateAttr != null && _templateCache.TryGetValue(templateAttr.Value, out var tplType))
                    return tplType;
            }

            return typeof(VisualElement);
        }

        public static string ToPascalCase(string name)
        {
            var parts = name.Split('-', '_');
            var result = "";
            foreach (var part in parts)
                if (!string.IsNullOrEmpty(part))
                    result += char.ToUpperInvariant(part[0]) + part.Substring(1);
            return result;
        }
    }
}
