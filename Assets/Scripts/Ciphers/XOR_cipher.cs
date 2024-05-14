using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class XOR_cipher : MonoBehaviour
{
    public InputField Input;
    public Text Conclusion;

    public InputField Key;

    static Image Key_Color;

    private void Start()
    {
        Key_Color = Key.GetComponent<Image>();
    }

    private void Update()
    {
            if (Input.text == "")
            {
                Conclusion.text = "";
            }
            EncryptionFunction();
    }

    public void Button_Clear()
    {
        Key.text = "";
        Input.text = "";
        Conclusion.text = "";
    }

    public void EncryptionFunction()
    {
        int value = 0;
        if (Key.text == "")
        {
            Key_Color.color = Color.green;
            Conclusion.color = Color.green;
            Conclusion.text = "";
        }
        else if (Key.text != "")
        {
            if (int.TryParse(Key.text, out value) == false)
            {
                Conclusion.color = Color.red;
                Conclusion.text = "Недопустимый символ";
                Key_Color.color = Color.red;
            }
            else if (int.TryParse(Key.text, out value) == true)
            {
                if (int.Parse(Key.text) < 0 || int.Parse(Key.text) > 65500)
                {
                    Conclusion.color = Color.red;
                    Conclusion.text = "Ключ должен быть в диапозоне от 0 до 65500";
                    Key_Color.color = Color.red;
                }
                else if (int.TryParse(Key.text, out value) == true)
                {
                    Conclusion.color = Color.green;
                    Key_Color.color = Color.green;
                    string str = Input.text;
                    int key = int.Parse(Key.text);
                    Conclusion.text = EncodeDecrypt(str, key);
                }
            }   
        }
    }

    static string EncodeDecrypt(string str, int secretKey)
    {
        var ch = str.ToArray();
        string newStr = "";
        foreach (var c in ch)
            newStr += TopSecret(c, secretKey);
        return newStr;
    }

    static char TopSecret(char character, int secretKey)
    {
        character = (char)(character ^ secretKey);
        return character;
    }
}
