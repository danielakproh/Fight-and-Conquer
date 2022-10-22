# class `MapGeneratorEditor`

## Purpose

Creates a custom editor interface for easier manipulations in the Unity's default inspector.

## Definition

```csharp
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {}
```

## Implementation
```csharp
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {
    public override void OnInspectorGUI() {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector()) {
            if (mapGen.autoUpdate) {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }
    }
}
```

## Description

The process of creating custom inspectors is explained in more details by the [Unity documentation](https://docs.unity3d.com/ScriptReference/Editor.html), but we basically inherit from the Unity's [Editor](https://docs.unity3d.com/ScriptReference/Editor.html) class and override the [OnInspectorGUI()](https://docs.unity3d.com/ScriptReference/Editor.OnInspectorGUI.html) method as described by the documentation. we have an if-statement that checks whether the user wants the map to automatically update, if such is the case, we generate a new map using a [MapGenerator]() object previously instantiated.













