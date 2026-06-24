<div align="center">
  
# UI Toolkit Code Behind

<img src="https://shieldcn.dev/badge/Unity-6000.4.8f1-ececec.png?variant=outline&logo=unity" alt="Unity">
<img src="https://shieldcn.dev/badge/C%23-9.0-239120.png?variant=outline&logo=csharp" alt="C#">
<img src="https://shieldcn.dev/badge/UPM-package-2196F3.png?variant=outline&logo=unity" alt="UPM">
<br>

Code-behind API + UXML-driven codegen for Unity UI Toolkit. Replaces hand-rolled element queries, factory classes, and manual cleanup with convention-based partial classes.
</div>



## Quick start

```csharp
using UITK.CodeBehind;
using UnityEngine.UIElements;

public sealed partial class MainMenuView : CodeBehindView
{
    public MainMenuView(VisualTreeAsset template) : base(template) { }

    protected override void Bind()
    {
        OnClick(SoloBtn, () => UIRouter.Instance.NavigateTo<SoloView>());
    }
}
```

- **Editor:** `Tools/Code Behind/New View` creates UXML + `.cs` + generated wiring
- **Generated** `MainMenuView.g.cs` provides `SoloBtn`, `CoopBtn`, etc. fields from UXML `name` attributes
- **Lifecycle:** `OnActivate()` (generated) → `Bind()` (your code) → auto-unsubscribe on `Deactivate()`
- **Navigation:** `UIRouter.Instance.NavigateTo<T>()`, `OpenModal<T>()`, `Back()`

## Install

In `Packages/manifest.json`:

```json
"com.yourname.uitk-codebehind": "https://github.com/SBUplakankus/ui-toolkit-code-behind.git"
```

Or local path:

```json
"com.yourname.uitk-codebehind": "file:../path/to/ui-toolkit-code-behind"
```

## Package API

### Runtime (`UITK.CodeBehind`)

| Type | Role |
|---|---|
| `CodeBehindView` | Abstract base — lifecycle, auto-cleanup subscription helpers, DataSource binding |
| `UIRouter` | Singleton navigator — `NavigateTo<T>()`, `OpenModal<T>()`, `Back()`, modal stack |
| `UILayer` | Stack container — `Push()`, `Pop()`, `Clear()` |
| `ElementQueries` | `B()`/`L()`/`S()`/`I()`/`V()` — terse element queries with TemplateContainer unwrapping |
| `ViewFactory` | `Resources.Load("Views/{Name}")` + `Activator.CreateInstance` |

### Editor (`UITK.CodeBehind.Editor`)

| Type | Role |
|---|---|
| `UxmlScanner` | Parses UXML, discovers named elements, infers types from templates |
| `CodeBehindGenerator` | Produces `{Name}View.g.cs` — fields + `OnActivate()` |
| `ViewScaffolder` | Menu item `Tools/Code Behind/New View` |
| `UxmlAssetPostprocessor` | Auto-regenerates on UXML save |

## Demo

Import `Samples > Demo Game UI` via Package Manager to see navigation, chrome, modals, data binding, and audio in action.

## License

MIT
