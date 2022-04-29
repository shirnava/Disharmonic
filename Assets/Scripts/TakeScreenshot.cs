using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TakeScreenshot : MonoBehaviour
{
    Camera cam;
    public string pathFolder;
    

    private void Awake()
    {
        cam = GetComponent<Camera>();
        Screenshot(pathFolder);
    }
    
    public void Screenshot(string Path)
    {
        RenderTexture rendert = new RenderTexture(256,256,24);
        cam.targetTexture = rendert;
        Texture2D sshot = new Texture2D(256,256,TextureFormat.RGBA32,false);
        cam.Render();
        RenderTexture.active = rendert;
        sshot.ReadPixels(new Rect(0,0,256,256),0,0);
        cam.targetTexture = null;
        RenderTexture.active = null;

        if(Application.isEditor)
        {
            DestroyImmediate(rendert);
        }
        else
        {
            Destroy(rendert);
        }
        byte[] bytes = sshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(pathFolder, bytes);
        // AssetDatabase.Refresh();
    }
}
