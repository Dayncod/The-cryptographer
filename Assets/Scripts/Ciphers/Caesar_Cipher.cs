using UnityEngine;
using UnityEngine.UI;

public class Caesar_Cipher : MonoBehaviour
{
    private const string Ru_alf = "абвгдеЄжзийклмнопрстуфхцчшщъыьэю€";
    private const string Ru_AlfUpper = "јЅ¬√ƒ≈®∆«»… ЋћЌќѕ–—“”‘’÷„ЎўЏџ№Ёёя";

    private const string En_alf = "abcdefghijklmnopqrstuvwxyz";
    private const string En_AlfUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public InputField Input;
    public Text Conclusion;

    public InputField Key;
    public Dropdown Language;
    public Dropdown EN_DE;

    static Image Key_Color;

    private void Start()
    {
        Key_Color = Key.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.text == "")
        {
            Conclusion.text = "";
        }
        else
        {
            EncryptionFunction();
        }
    }

    public void EncryptionFunction()
    {
        if (Key.text != "")
        {
            int value = 0;

            string str = Input.text;

            if (int.TryParse(Key.text, out value) == false)
            {
                Conclusion.color = Color.red;
                Conclusion.text = "Ќедопустимый символ";
                Key_Color.color = Color.red;
            }
            else
            {
                Key_Color.color = Color.green;

                int key = int.Parse(Key.text);

                if (Language.value == 0)
                {
                    if (key <= 0 || key > Ru_alf.Length || key > Ru_AlfUpper.Length)
                    {
                        Conclusion.color = Color.red;
                        Conclusion.text = $" люч должен быть от 1 до {Ru_alf.Length}";
                        Key_Color.color = Color.red;
                    }
                    else
                    {
                        Key_Color.color = Color.green;
                        Conclusion.color = Color.green;
                        if (EN_DE.value == 0)
                        {
                            Conclusion.text = Ru_Cezar(str, key, EN_DE.value);
                        }
                        else if (EN_DE.value == 1)
                        {
                            Conclusion.text = Ru_Cezar(str, key, EN_DE.value);
                        }
                    }
                }
                else if (Language.value == 1)
                {
                    if (key <= 0 || key > En_alf.Length || key > En_AlfUpper.Length)
                    {
                        Conclusion.color = Color.red;
                        Conclusion.text = $" люч должен быть от 1 до {En_alf.Length}";
                        Key_Color.color = Color.red;
                    }
                    else
                    {
                        Key_Color.color = Color.green;
                        Conclusion.color = Color.green;
                        if (EN_DE.value == 0)
                        {
                            Conclusion.text = En_Cezar(str, int.Parse(Key.text), EN_DE.value);
                        }
                        else if (EN_DE.value == 1)
                        {
                            Conclusion.text = En_Cezar(str, int.Parse(Key.text), EN_DE.value);
                        }
                    }
                }
            }
        }
        else if (Key.text == "")
        {
            Conclusion.color = Color.green;
            Key_Color.color = Color.green;
        }
    }

    static string Ru_Cezar(string text, int Ru_key, int direction)
    {
        string rez = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (direction == 0)
            {
                if (Ru_alf.Contains(text[i]))
                {
                    char ch;
                    int index = Ru_alf.IndexOf(text[i]) + Ru_key;
                    if (Ru_alf.IndexOf(text[i]) + Ru_key > Ru_alf.Length - 1)
                    {
                        ch = Ru_alf[Ru_alf.IndexOf(text[i]) - (Ru_alf.Length - Ru_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = Ru_alf[index];
                        rez += ch;
                    }
                }
                else if (Ru_AlfUpper.Contains(text[i]))
                {
                    char ch;
                    int index = Ru_AlfUpper.IndexOf(text[i]) + Ru_key;
                    if (Ru_AlfUpper.IndexOf(text[i]) + Ru_key > Ru_alf.Length - 1)
                    {
                        ch = Ru_AlfUpper[Ru_AlfUpper.IndexOf(text[i]) - (Ru_AlfUpper.Length - Ru_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = Ru_AlfUpper[index];
                        rez += ch;
                    }
                }
                else if (!Ru_alf.Contains(text[i]) && !Ru_AlfUpper.Contains(text[i]))
                {
                    rez += text[i];
                }
            }
            else if (direction == 1)
            {
                if (Ru_alf.Contains(text[i]))
                {
                    char ch;
                    int index = Ru_alf.IndexOf(text[i]) - Ru_key;
                    if (Ru_alf.IndexOf(text[i]) - Ru_key < 0)
                    {
                        ch = Ru_alf[Ru_alf.IndexOf(text[i]) + (Ru_alf.Length - Ru_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = Ru_alf[index];
                        rez += ch;
                    }
                }
                else if (Ru_AlfUpper.Contains(text[i]))
                {
                    char ch;
                    int index = Ru_AlfUpper.IndexOf(text[i]) - Ru_key;
                    if (Ru_AlfUpper.IndexOf(text[i]) - Ru_key < 0)
                    {
                        ch = Ru_AlfUpper[Ru_AlfUpper.IndexOf(text[i]) + (Ru_AlfUpper.Length - Ru_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = Ru_AlfUpper[index];
                        rez += ch;
                    }
                }
                else if (!Ru_alf.Contains(text[i]) && !Ru_AlfUpper.Contains(text[i]))
                {
                    rez += text[i];
                }
            }
        }
        return rez;
    }

    static string En_Cezar(string text, int En_key, int direction)
    {
        string rez = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (direction == 0)
            {
                if (En_alf.Contains(text[i]))
                {
                    char ch;
                    int index = En_alf.IndexOf(text[i]) + En_key;
                    if (En_alf.IndexOf(text[i]) + En_key > En_alf.Length - 1)
                    {
                        ch = En_alf[En_alf.IndexOf(text[i]) - (En_alf.Length - En_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = En_alf[index];
                        rez += ch;
                    }
                }
                else if (En_AlfUpper.Contains(text[i]))
                {
                    char ch;
                    int index = En_AlfUpper.IndexOf(text[i]) + En_key;
                    if (En_AlfUpper.IndexOf(text[i]) + En_key > Ru_alf.Length - 1)
                    {
                        ch = En_AlfUpper[En_AlfUpper.IndexOf(text[i]) - (En_AlfUpper.Length - En_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = En_AlfUpper[index];
                        rez += ch;
                    }
                }
                else if (!En_alf.Contains(text[i]) && !En_AlfUpper.Contains(text[i]))
                {
                    rez += text[i];
                }
            }
            else if (direction == 1)
            {
                if (En_alf.Contains(text[i]))
                {
                    char ch;
                    int index = En_alf.IndexOf(text[i]) - En_key;
                    if (En_alf.IndexOf(text[i]) - En_key < 0)
                    {
                        ch = En_alf[En_alf.IndexOf(text[i]) + (En_alf.Length - En_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = En_alf[index];
                        rez += ch;
                    }
                }
                else if (En_AlfUpper.Contains(text[i]))
                {
                    char ch;
                    int index = En_AlfUpper.IndexOf(text[i]) - En_key;
                    if (En_AlfUpper.IndexOf(text[i]) - En_key < 0)
                    {
                        ch = En_AlfUpper[En_AlfUpper.IndexOf(text[i]) + (En_AlfUpper.Length - En_key)];
                        rez += ch;
                    }
                    else
                    {
                        ch = En_AlfUpper[index];
                        rez += ch;
                    }
                }
                else if (!En_alf.Contains(text[i]) && !En_AlfUpper.Contains(text[i]))
                {
                    rez += text[i];
                }
            }
        }
        return rez;
    }
}
