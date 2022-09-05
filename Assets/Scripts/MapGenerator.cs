using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

        public int mapWidth;
        public int mapHeight;
        public float noiseScale;

        public int octaves;
        public float persistence;
        public float lacunarity;

        public bool autoUpdate;
        
        public void GenerateMap() {
            float[,] map = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale,octaves,persistence,lacunarity  );

            if(TryGetComponent<MapDisplay>(out MapDisplay display)) 
                display.DrawNoiseMap(map);
        }
        
}
