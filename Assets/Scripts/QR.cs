using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QR : MonoBehaviour
{
    public RawImage QRCode;
    public InputField QRText;

    public Color32[] GeneQRCode(string formatStr, int width, int height)
    {
        ZXing.QrCode.QrCodeEncodingOptions options = new ZXing.QrCode.QrCodeEncodingOptions();

        options.CharacterSet = "UTF-8";

        options.Width = width;
        options.Height = height;
        options.Margin = 1;

        BarcodeWriter QR = new BarcodeWriter { Format = BarcodeFormat.QR_CODE, Options = options };

        return QR.Write(formatStr);
    }

    public Texture2D ShowQRCode(string str, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);

        Color32[] colors = GeneQRCode(str, width, height);

        texture.SetPixels32(colors);
        texture.Apply();
        return texture;
    }

    public Texture2D DrowQRCode(string formatStr)
    {
        Texture2D texture = ShowQRCode(formatStr, 256, 256);                                              
        return texture;
    }

    public void QRCreate()
    {
        Texture2D tex = DrowQRCode(QRText.text);
        tex.name = "QRtexture";
        QRCode.texture = tex;
    }
}
