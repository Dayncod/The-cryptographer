using UnityEngine;
using UnityEngine.UI;

public class Atbashcipher : MonoBehaviour
{
    private const string alf = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿ";
    private const string AlfUpper = "ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß";

    private const string En_alf = "abcdefghijklmnopqrstuvwxyz";
    private const string En_AlfUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public InputField Input;
    public Text Conclusion;


    private void Update()
    {
        Conclusion.text = Atbash(Input.text);
    }

    static string Atbash(string text)
    {
        string shifr = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (alf.Contains(text[i]))
            {
                int index = (alf.Length - 1) - alf.IndexOf(text[i]);
                shifr += alf[index];
            }
            else if (AlfUpper.Contains(text[i]))
            {
                int index = (AlfUpper.Length - 1) - AlfUpper.IndexOf(text[i]);
                shifr += AlfUpper[index];
            }
            else if (En_alf.Contains(text[i]))
            {
                int index = (En_alf.Length - 1) - En_alf.IndexOf(text[i]);
                shifr += En_alf[index];
            }
            else if (En_AlfUpper.Contains(text[i]))
            {
                int index = (En_AlfUpper.Length - 1) - En_AlfUpper.IndexOf(text[i]);
                shifr += En_AlfUpper[index];
            }
            else if (!alf.Contains(text[i]) && !AlfUpper.Contains(text[i]) && !En_alf.Contains(text[i]) && !En_AlfUpper.Contains(text[i]))
            {
                shifr += text[i];
            }
        }
        return shifr;
    }
}
