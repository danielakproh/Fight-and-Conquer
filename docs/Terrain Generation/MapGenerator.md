# class `MapGenerator`

## Description

Takes in map dimensions, generates noise map via [Noise]().GenerateNoiseMap() and draws noise map via [MapDisplay]().DrawNoiseMap().

## Definition

```csharp
    public class MapGenerator : MonoBehaviour {}
```

 
## Parameters

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

<br>

<!-- Return value  -->
## Returns
**Null**

## Implementation
```csharp
public class MapGenerator : MonoBehaviour {

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public void GenerateMap() {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);


        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }

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

}
```













