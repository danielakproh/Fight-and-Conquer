# class `MapGenerator`

## Description

Takes in map dimensions, generates noise map and draws the desired texture.

## Definition

```csharp
    public class MapGenerator : MonoBehaviour {}
```

## Fields
<!-- structs -->
**Structs**
<table>
 <tr style="text-align: center">
    <td><h3>Struct name<h3></td>
    <td><h3>Attribute<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>
  <tr style="text-align: center">
    <td rowspan="4">TerrainType</td>
  </tr>
  <tr style="text-align: center">
    <td>name</td>
    <td><code>String</code></td>
    <td>Name of terrain type</td>
  </tr>
 <tr style="text-align: center">
    <td>Height</td>
    <td><code>float</code></td>
    <td>Height of region</td>
  </tr>
 <tr style="text-align: center">
    <td>Color</td>
    <td><code>Color[]</code></td>
    <td>Color of the terrain</td>
  </tr>
</table>

<!-- other types -->
**Other types**
<table>
<!-- head -->
  <tr style="text-align: center">
    <td><h3>Parameter<h3></td>
    <td><h3>Type<h3></td>
    <td><h3>Description</h3></td>
  </tr>

  <tr>
    <td><code>mapWidth</code></td>
    <td><code>int</code></td>
    <td>Value representing the desired width of the noise map.</td>
  </tr>
  <tr>
    <td><code>mapHeight</code></td>
    <td><code>int</code></td>
    <td>Value representing the desired height of the noise map.</td>
  </tr>
  <tr>
    <td><code>noiseScale</code></td>
    <td><code>float</code></td>
    <td>The distance between consecutive coordinates. The smaller the scale, the closer the points and the higher the resolution of the map.</td>
  </tr>
   <tr>
    <td><code>octaves</code></td>
    <td><code>int</code></td>
    <td>Value determining the number of noise maps to overlay.</td>
  </tr>
  <tr>
    <td><code>persistance</code></td>
    <td><code>float</code></td>
    <td>Value updating the noise height amplitude to produce a more natural result.</td>
  </tr>
  <tr>
    <td><code>lacunarity</code></td>
    <td><code>float</code></td>
    <td>Value udpating the frequency of the noise; in other words, the number of bumps per noise map.</td>
  </tr>
  <tr>
    <td><code>offset</code></td>
    <td><code>Vector2</code></td>
    <td>Value contributing to generate each octave at different pseudo-random positions.</td>
  </tr>
  <tr>
    <td><code>autoUpdate</code></td>
    <td><code>Vector2</code></td>
    <td>Value determining whether the map should update automatically when a parameter is modified.</td>
  </tr>
</table>

## Functions
**GenerateMap**
```csharp
    public void GenerateMap()
```

### Description
Generates noise map with desired dimensions and assigns each pixel a color determined by the **TerrainType** rules.

<br>

<!-- Return value  -->
### Returns : **Null**

### Implementation
```csharp
public void GenerateMap() {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colorMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++) {
                    if (currentHeight <= regions[i].height) {
                        colorMap[y * mapWidth + x] = regions[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap) {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColorMap) {
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
    }
```
<br>

**OnValidate**
```csharp
    void OnValidate()
```

### Description
[Unity function](https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnValidate.html) that gets excecuted when something change within the inspector.

<br>

<!-- Return value  -->
### Returns : **Null**

### Implementation
```csharp
void OnValidate() {

        if (mapWidth < 1) {
            mapWidth = 1;
        }
        if (mapHeight < 1) {
            mapHeight = 1;
        }
        if (lacunarity < 1) {
            lacunarity = 1;
        }
        if (octaves < 0) {
            octaves = 0;
        }
    }
```
<br>














