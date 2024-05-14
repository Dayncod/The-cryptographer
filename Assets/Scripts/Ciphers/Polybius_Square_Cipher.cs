using Newtonsoft.Json.Linq;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Polybius_Square_Cipher : MonoBehaviour
{
    private char[,] Ru_alf = { { 'à', 'á', 'â', 'ã', 'ä', 'å' },
                               { '¸', 'æ', 'ç', 'è', 'é', 'ê' },
                               { 'ë', 'ì', 'í', 'î', 'ï', 'ð' },
                               { 'ñ', 'ò', 'ó', 'ô', 'õ', 'ö' },
                               { '÷', 'ø', 'ù', 'ú', 'û', 'ü' },
                               { 'ý', 'þ', 'ÿ', '.', ',', '-' }};

    private char[,] En_alf = { { 'a', 'b', 'c', 'd', 'e' },
                               { 'f', 'g', 'h', 'i', 'k' },
                               { 'l', 'm', 'n', 'o', 'p' },
                               { 'q', 'r', 's', 't', 'u' },
                               { 'v', 'w', 'x', 'y', 'z' }};

    public InputField Input;
    public Text Conclusion;

    public Dropdown Language;
    public Dropdown EN_DE;

    void Update()
    {
        if (Input.text != "")
        {
            if (EN_DE.value == 0)
            {
                if (Language.value == 0)
                {
                    Conclusion.text = Ru_EncryptionFunction(Input.text);
                }
                else if (Language.value == 1)
                {
                    Conclusion.text = En_EncryptionFunction(Input.text);
                }
            }
            else if (EN_DE.value == 1)
            {
                if (Language.value == 0)
                {
                    Conclusion.text = Ru_DecryptionFunction(Input.text);
                }
                else if (Language.value == 1)
                {
                    Conclusion.text = En_DecryptionFunction(Input.text);
                }
            }
        }
        else if (Input.text == "") 
        {
            Conclusion.text = "";
        }
    }

    public string Ru_EncryptionFunction(string text)
    {
        text = text.ToLower();
        string result = "";
        for (int t = 0; t < text.Length; t++)
        {
            for (int i = 0; i < Ru_alf.GetLength(0); i++)
            {
                for (int j = 0; j < Ru_alf.GetLength(1); j++)
                {
                    if (text[t] == Ru_alf[i, j])
                    {
                        result += $"{i + 1}{j + 1} ";
                    }
                }
            }
        }
        return result;     
    }

    public string En_EncryptionFunction(string text)
    {
        text = text.ToLower();
        string result = "";
        for (int t = 0; t < text.Length; t++)
        {
            for (int i = 0; i < En_alf.GetLength(0); i++)
            {
                for (int j = 0; j < En_alf.GetLength(1); j++)
                {
                    if (text[t] == En_alf[i, j])
                    {
                        result += $"{i + 1}{j + 1} ";
                    }
                }
            }
            if (text[t] == 'j')
            {
                result += "24 ";
            }
        }
        return result;
    }

    public string Ru_DecryptionFunction(string text)
    {
        int value;

        string result = "";
        string[] strIntArr = text.Split(' ');
        for (int n = 0; n < strIntArr.Length; n++)
        {
            if (!int.TryParse(strIntArr[n], out value))
            {
                break;
            }

            int coord_i = int.Parse(strIntArr[n]) / 10;
            int coord_j = int.Parse(strIntArr[n]) % 10;

            for (int i = 1; i < Ru_alf.Length; i++)
            {
                for (int j = 1; j < Ru_alf.Length; j++)
                {
                    if (i == coord_i && j == coord_j)
                    {
                        result += Ru_alf[i - 1, j - 1];
                    }
                }
            }
        }
        return result.ToUpper();
    }

    public string En_DecryptionFunction(string text)
    {
        int value;

        string result = "";
        string[] strIntArr = text.Split(' ');
        for (int n = 0; n < strIntArr.Length; n++)
        {
            if (!int.TryParse(strIntArr[n], out value))
            {
                break;
            }

            int coord_i = int.Parse(strIntArr[n]) / 10;
            int coord_j = int.Parse(strIntArr[n]) % 10;

            for (int i = 1; i < En_alf.Length; i++)
            {
                for (int j = 1; j < En_alf.Length; j++)
                {
                    if (i == coord_i && j == coord_j)
                    {
                        result += En_alf[i - 1, j - 1];
                    }
                }
            }
        }
        return result.ToUpper();
    }
}
