
using UnityEngine;

public static class Noise {
    
    public static float[,] GenerateNoiseMap(int width, int height,float scale,int octaves,float persistance,float lacunarity) {

        float[,] map = new float[width, height];
        
        scale = scale <= 0 ? 0.0001f : scale;

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {

                float amplitude = 1f; // y axis ; height of the land
                float frequency = 1f; // x axis ; repetition of the land 
                float noiseHeight = 0f;
                
                for (int i = 0; i < octaves; i++) {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinVal = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1; // Allow to have negative value to have more natural land
                    noiseHeight = perlinVal * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity; 
                }

                maxNoiseHeight = noiseHeight > maxNoiseHeight ? noiseHeight : maxNoiseHeight;
                minNoiseHeight = noiseHeight < minNoiseHeight ? noiseHeight : minNoiseHeight;
                
                map[x, y] = noiseHeight;
            }
        }

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                map[x, y] = Mathf.InverseLerp(minNoiseHeight,maxNoiseHeight,map[x,y]);
            }
        }

        return map;

    }

}
