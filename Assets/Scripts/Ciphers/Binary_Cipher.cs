using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Binary_Cipher : MonoBehaviour
{
    public InputField Input;
    public Text Conclusion;

    public Dropdown EN_DE;


    void Update()
    {
        if (Input.text == "")
        {
            Conclusion.text = "";
        }
        else
        {
            if (EN_DE.value == 0)
            {
                Conclusion.text = ToByte(Input.text);
            }
            else if (EN_DE.value == 1)
            {
                Conclusion.text = ToText(Input.text);
            }
        }
    }

    static string ToByte(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);

        string code = "";

        char[] bits;

        foreach (char item in bytes)
        {
            int index = item;
            string str = "";

            for (int i = 0; index >= 1; i++)
            {
                int bit = index % 2;
                int devide = index / 2;
                index = devide;
                str += bit.ToString();
            }

            if (str.Length < 8)
            {
                while (str.Length < 8)
                {
                    str += "0";
                }
            }

            bits = str.ToCharArray();
            code += " " + Reverse(bits);
        }
        return code.TrimStart(' ');
    }

    static string ToText(string binare)

    {
        string text;

        string[] arrayStringBytes = binare.Split(' ');

        byte[] utf = new byte[arrayStringBytes.Length];

        for (int i = 0; i < arrayStringBytes.Length; i++)
        {
            char[] bits = arrayStringBytes[i].ToCharArray();
            string reversStringBytes = Reverse(bits);

            int utf8Byte = 0;
            for (int j = 0; j < reversStringBytes.Length; j++)
            {
                string stringValue = reversStringBytes[j].ToString();
                int value = int.Parse(stringValue);

                utf8Byte += (value * (int)Math.Pow(2, j));
            }
            utf[i] = (byte)utf8Byte;
        }
        text = Encoding.UTF8.GetString(utf);
        return text.TrimStart(' ');
    }

    static string Reverse(char[] bits)
    {
        Array.Reverse(bits);
        string Rev = new string(bits);
        return Rev;
    }
}
