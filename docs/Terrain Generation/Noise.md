# class `Noise`

## Purpose

Generates noise map using Perlin Noise 

## Definition

```csharp
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistence, float lacunarity, Vector2 offset);
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
    <td><code>scale</code></td>
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
</table>

<br>

<!-- Return value  -->
## Returns
**float[ , ]** A 2-Dimensional array containing noise values comprised between 0 and 1.

## Description
Generates a noise map and return a grid of values between 0 and 1. (Values genrated using [Perlin Noise](https://en.wikipedia.org/wiki/Perlin_noise))

## Implementation
```csharp
public static class Noise { 
    // create grid of size width and height
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset) {
        
        float[,] noiseMap = new float[mapWidth, mapHeight];

        // avoiding division by zero
        if (scale <=0) {
            scale = 0.0001f;
        }

        // pseudo-random offsets to create map layers in pseudo-random locations
        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++) {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(- 100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        // since noiseMap will contain values outside of the [0-1] range, we keep track of the max & min values to interpolate later on
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;


        // generate height values using perlin noise algorithm
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++) {
                    float sampleX = x / scale * frequency + octaveOffsets[i].x;
                    float sampleY = y / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                    noiseHeight += perlinValue * amplitude;

                    // the range of height values is bounded
                    if (noiseHeight > maxNoiseHeight) {
                        maxNoiseHeight = noiseHeight;
                    }
                    else if (noiseHeight < minNoiseHeight) {
                        minNoiseHeight = noiseHeight;
                    }

                    noiseMap[x, y] = noiseHeight;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

            }
        }

        // normalize perlinValue between 0 and 1 before returning
        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
                
        return noiseMap;

    }

}
```













