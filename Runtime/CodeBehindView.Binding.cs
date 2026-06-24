using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace UITK.CodeBehind
{
    public abstract partial class CodeBehindView
    {
        // --- Data Source ---

        protected void SetDataSource(VisualElement target, object dataSource)
        {
            target.dataSource = dataSource;
            _cleanup.Add(() => target.dataSource = null);
        }

        protected void SetDataSourcePath(VisualElement target, string path)
        {
            target.dataSourcePath = new PropertyPath(path);
            _cleanup.Add(() => target.dataSourcePath = default);
        }

        // --- Binding shortcuts ---

        protected void BindLabelText(Label target, string path) => SetDataSourcePath(target, path);

        protected void BindTextFieldValue(TextField target, string path) => SetDataSourcePath(target, path);

        protected void BindToggleValue(Toggle target, string path) => SetDataSourcePath(target, path);

        protected void BindSliderValue(Slider target, string path) => SetDataSourcePath(target, path);

        protected void BindSliderValue(SliderInt target, string path) => SetDataSourcePath(target, path);

        protected void BindIntFieldValue(IntegerField target, string path) => SetDataSourcePath(target, path);

        protected void BindLongFieldValue(LongField target, string path) => SetDataSourcePath(target, path);

        protected void BindFloatFieldValue(FloatField target, string path) => SetDataSourcePath(target, path);

        protected void BindDoubleFieldValue(DoubleField target, string path) => SetDataSourcePath(target, path);

        protected void BindDropdownValue(DropdownField target, string path) => SetDataSourcePath(target, path);

        protected void BindRadioButtonValue(RadioButton target, string path) => SetDataSourcePath(target, path);

        protected void BindVector2Value(Vector2Field target, string path) => SetDataSourcePath(target, path);

        protected void BindVector3Value(Vector3Field target, string path) => SetDataSourcePath(target, path);

        // --- Dynamic Lists ---

        protected void BindList<T>(VisualElement container, IEnumerable<T> items, Func<T, VisualElement> createItem)
        {
            container.Clear();
            foreach (var item in items)
                container.Add(createItem(item));
            _cleanup.Add(() => container.Clear());
        }
    }
}
