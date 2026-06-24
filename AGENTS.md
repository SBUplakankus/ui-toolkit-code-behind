# AGENTS.md

`com.sbuplakankus.uitk-codebehind` — a UPM package providing a code-behind API + UXML-driven codegen for Unity UI Toolkit. Targets Unity 6000.4.8f1 (C# 9, .NET Standard 2.1).

## Repo structure

```
Runtime/           — public API assembly (UITK.CodeBehind)
Editor/            — codegen, scanner, scaffolder (UITK.CodeBehind.Editor)
Samples~/Demo/     — full game UI demo, import via Package Manager
package.json       — UPM package manifest
```

The original hand-rolled reference lives frozen at `C:\Users\tremo\Documents\GitHub\ui-toolkit-waw`.

The full Unity game project that this package was extracted from is on the `sample-game` branch.

## Package API

### Runtime (`UITK.CodeBehind`)

| Type | Purpose |
|---|---|
| `CodeBehindView` | Abstract base for every view. Owns `Root`, lifecycle, subscription tracker, `OnClick`/`OnValueChanged`/etc. helpers, DataSource binding API. |
| `UIRouter` | Plain C# singleton. `Init(screenLayer, modalLayer)`, `NavigateTo<T>()`, `OpenModal<T>()`, `Back()`, `CloseModal()`, `ClearModals()`. Events: `ScreenChanged`, `ModalOpened`, `ModalClosed`, `ModalsCleared`. |
| `UILayer` | Stack container for views. `Push(view)`, `Pop()`, `Clear()`. |
| `ElementQueries` | Extension methods: `B(name)` → Button, `L(name)` → Label, `S(name)` → Slider, `I(name)` → Image, `V(name)` → VisualElement. Unwrap `TemplateContainer` automatically. |
| `ViewFactory` | Convention-based loader: `Resources.Load<VisualTreeAsset>($"Views/{name}")` + `Activator.CreateInstance`. |
| `HeaderNameAttribute` | `[HeaderName("STRING")]` marker — consumers read it for chrome titles. |

### Editor (`UITK.CodeBehind.Editor`)

| Type | Purpose |
|---|---|
| `UxmlScanner` | Parses UXML, extracts `name` attributes, infers types via template auto-discovery. Skips `src`-bearing elements and root containers. |
| `CodeBehindGenerator` | Drives the scanner, writes `{Name}View.g.cs` files with field declarations + `OnActivate()` override. |
| `ViewScaffolder` | Editor menu: `Tools/Code Behind/New View`. Creates UXML + behavior `.cs` pair. |
| `UxmlAssetPostprocessor` | Auto-regenerates on UXML save/delete in `Assets/Resources/Views/`. |

## Architecture rules

- **UXML filename MUST match the C# class name exactly (case-sensitive).** `ViewFactory` loads `Resources/Views/{TypeName}`.
- **View classes are `partial`.** The behavior file holds logic, the `.g.cs` holds generated wiring.
- **View classes extend `CodeBehindView`.** Use `[HeaderName("TITLE")]` for chrome titles.
- **UXML `name` attributes are the source of truth.** `name="solo-btn"` → PascalCase field `SoloBtn` in `.g.cs`.
- **Generated files go in `Assets/Scripts/UI/Generated/Views/`** — never hand-edit.
- **`UIRouter` is a plain C# singleton.** Call `UIRouter.Instance.Init(screenLayer, modalLayer)` before use.

## Adding a new view

1. `Tools/Code Behind/New View` → enters name → creates UXML + `.cs` + generates `.g.cs`
2. Open UXML in UI Builder, add elements with `name` attributes
3. In `.cs`, add `[HeaderName("TITLE")]` if needed, write `OnClick(SoloBtn, HandleClicked)` in `Bind()`
4. Regenerate via `Tools/Code Behind/Regenerate` or save UXML

## Subscription & binding helpers

All auto-unbind on `Deactivate()`. See `CodeBehindView.Events.cs` and `CodeBehindView.Binding.cs` for the full list.

## Consuming from another project

In `Packages/manifest.json`:
```json
"com.sbuplakankus.uitk-codebehind": "file:../../path/to/ui-toolkit-code-behind"
```

## Sample

The `Samples~/Demo/` folder contains a full game UI demo. Import it via Package Manager → `UITK.CodeBehind` → `Demo Game UI` → Import. Includes 24 views, navigation (screen + modal), chrome bar, audio handler, and data binding examples.

## Publishing to Asset Store

1. Open the package in a Unity project with the Asset Store Tools installed
2. Run `Tools/Asset Store Tools/Validator` to check structure
3. Use the Uploader to publish via Publisher Portal

## Build / test

- **No CLI build.** Open in Unity Hub / Editor.
- **No test suite.** Tests deleted with the old hand-written patterns; new suite pending.
