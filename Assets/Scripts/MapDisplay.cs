using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

    public Renderer texRenderer;

    public void DrawNoiseMap(float[,] map) {
        
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                
                texture.SetPixel(x,y,Color.Lerp(Color.black,Color.white,map[x,y]));
            }
        }
        
        texture.Apply();

        texRenderer.sharedMaterial.mainTexture = texture;
        texRenderer.transform.localScale = new Vector3(width,1,height);
    }
}
