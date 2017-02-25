using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PointFilterProcessor : AssetPostprocessor
{

    public void OnPostprocessTexture(Texture2D texture)
    {
        //If is in Sprites director it will change the texture into point filter
        if (assetPath.Contains("Sprites"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.filterMode = FilterMode.Point;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
    
}