using UITK.CodeBehind;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Views
{
    public sealed partial class ButtonsView : CodeBehindView
    {
        private static readonly string[] DemoItems = { "Alpha", "Bravo", "Charlie", "Delta" };

        public ButtonsView(VisualTreeAsset template) : base(template) { }

        protected override void Bind()
        {
            OnClick(DemoBtn, HandleClick);
            OnClick(DemoTab, OnTabClicked);
            OnClick(DemoFoldout, OnFoldClicked);
            OnClick(DemoToggleGroup, OnToggleGroupClicked);
            OnHover(DemoBtn, OnBtnHover);

            BindList(DemoListCtr, DemoItems, item =>
                new Button(() => Debug.Log(item)) { text = item }
            );
        }

        private static void HandleClick() => Debug.Log("Button clicked");
        private static void OnTabClicked(ClickEvent evt) => Debug.Log("Tab clicked");
        private static void OnFoldClicked(ClickEvent evt) => Debug.Log("Foldout clicked");
        private static void OnToggleGroupClicked(ClickEvent evt) => Debug.Log("Toggle group clicked");
        private static void OnBtnHover(PointerEnterEvent evt) => Debug.Log("Hover");
    }
}
