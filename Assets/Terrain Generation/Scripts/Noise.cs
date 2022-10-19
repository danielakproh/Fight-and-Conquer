using System.Collections;
using UnityEngine;

public static class Noise
{
    // amplitude: y axis
    // frequency: x axis
    // lacunarity: controls increase frequency of octaves
    // persistance: controls decrease in amplitude

    // generate a noise map: return a grid of values between 0 and 1
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale) {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        if (scale <=0) {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }
}
