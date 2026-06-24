using UnityEngine.UIElements;

namespace UITK.CodeBehind
{
    public static class ElementQueries
    {
        public static Button B(this VisualElement root, string name)
        {
            var direct = root.Q<Button>(name);
            if (direct != null) return direct;
            var ctr = root.Q<TemplateContainer>(name);
            return ctr?.Q<Button>();
        }

        public static Slider S(this VisualElement root, string name)
        {
            var direct = root.Q<Slider>(name);
            if (direct != null) return direct;
            var ctr = root.Q<TemplateContainer>(name);
            return ctr?.Q<Slider>();
        }

        public static Label L(this VisualElement root, string name) => root.Q<Label>(name);
        public static Image I(this VisualElement root, string name) => root.Q<Image>(name);
        public static VisualElement V(this VisualElement root, string name) => root.Q<VisualElement>(name);
    }
}
