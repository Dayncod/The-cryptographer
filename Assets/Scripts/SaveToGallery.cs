using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class SaveToGallery : MonoBehaviour
{
    public RawImage QRCode;
    static Texture2D image;

    private void Start()
    {


        
    }

    private IEnumerator SavingProcess()
    {
        yield return new WaitForEndOfFrame();

        image = new Texture2D(QRCode.texture.width, QRCode.texture.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(QRCode.transform.localPosition.x, QRCode.transform.localPosition.y, QRCode.texture.width, QRCode.texture.height), 0, 0);
        image.LoadRawTextureData(image.GetRawTextureData());
        image.Apply();
        image = RawImageToTexture2D(QRCode, image);
        NativeGallery.SaveImageToGallery(image, "GalleryTest", "My QR {0}.png");
    }

    public void SaveImage()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) == false)
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            print("Запрос на доступ к памяти устройста");
            if (Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) == true)
            {
                StartCoroutine(SavingProcess());
            }
            else
            {
                return;
            }
        }
        else
        {
            print("Запрос был принят");
            StartCoroutine(SavingProcess());
        }
    }

    private Texture2D RawImageToTexture2D(RawImage tex, Texture2D img)
    {
        img = new Texture2D(tex.texture.width, tex.texture.height, TextureFormat.RGB24, false);

        img.ReadPixels(new Rect(0, 0, tex.texture.width, tex.texture.height), 0, 0);
        img.Apply();

        return img;
    }

}
