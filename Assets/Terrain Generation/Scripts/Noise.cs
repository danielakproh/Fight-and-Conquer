using System.Collections;
using System.Linq;
using UnityEngine;

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

                    amplitude *= persistance; // 0<=persistance<=1
                    frequency *= lacunarity; // lacunarity>=1
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
