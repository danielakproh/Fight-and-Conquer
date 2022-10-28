using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
// takes in a noise map and turns it into a texture then applies that texture to a plane GameObject
{
    public Renderer textureRenderer;

    public void DrawTexture(Texture2D texture) {
        // allows generation without always having to enter game mode
        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
