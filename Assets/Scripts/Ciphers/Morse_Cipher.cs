using System;
using UnityEngine;
using UnityEngine.UI;

public class Morse_Cipher : MonoBehaviour
{
    public InputField Input;
    public Text Conclusion;

    public Dropdown EN_DE;
    public Dropdown Language;

    void Update()
    {
        EncryptionFunction();
    }

    public void EncryptionFunction()
    {
        if (EN_DE.value == 0)
        {
            if (Language.value == 0)
            {
                if (Input.text == "")
                {
                    Conclusion.text = "";
                }
                else if (ru_EN_Morze(Input.text) == "")
                {
                    Conclusion.color = Color.red;
                    Conclusion.text = "Введите русские буквы";
                }
                else
                {
                    Conclusion.color = Color.green;
                    Conclusion.text = ru_EN_Morze(Input.text);
                }
            }
            else if (Language.value == 1)
            {
                if (Input.text == "")
                {
                    Conclusion.text = "";
                }
                else if (en_EN_Morze(Input.text) == "")
                {
                    Conclusion.color = Color.red;
                    Conclusion.text = "Введите англиские буквы";
                }
                else
                {
                    Conclusion.color = Color.green;
                    Conclusion.text = en_EN_Morze(Input.text);
                }
            }
        }
        else if (EN_DE.value == 1)
        {
            if (Language.value == 0)
            {
                if (Input.text == "")
                {
                    Conclusion.text = "";
                }
                else
                {
                    Conclusion.color = Color.green;
                    string[] strArr = Input.text.Split(' ');
                    string rez = "";
                    foreach (string str in strArr)
                    {
                        rez += ru_DE_Morze(str);
                    }
                    Conclusion.text = rez;
                }
            }
            else if (Language.value == 1)
            {
                if (Input.text == "")
                {
                    Conclusion.text = "";
                }
                else
                {
                    Conclusion.color = Color.green;
                    string[] strArr = Input.text.Split(' ');
                    string rez = "";
                    foreach (string str in strArr)
                    {
                        rez += en_DE_Morze(str);
                    }
                    Conclusion.text = rez;
                }
            }
        }
    }

    static string ru_EN_Morze(string text)
    {
        string rez = "";
        foreach (char ch in text)
        {
            if (Char.IsWhiteSpace(ch) == true)
            {
                rez += " / ";
            }
            switch (ch)
            {
                case 'А': rez += " .- "; break;
                case 'а': rez += " .- "; break;

                case 'Б': rez += " -... "; break;
                case 'б': rez += " -... "; break;

                case 'В': rez += " .-- "; break;
                case 'в': rez += " .-- "; break;

                case 'Г': rez += " --. "; break;
                case 'г': rez += " --. "; break;

                case 'Д': rez += " -.. "; break;
                case 'д': rez += " -.. "; break;

                case 'Е': rez += " . "; break;
                case 'е': rez += " . "; break;

                case 'Ё': rez += " . "; break;
                case 'ё': rez += " . "; break;

                case 'Ж': rez += " ...- "; break;
                case 'ж': rez += " ...- "; break;

                case 'З': rez += " --.. "; break;
                case 'з': rez += " --.. "; break;

                case 'И': rez += " .. "; break;
                case 'и': rez += " .. "; break;

                case 'Й': rez += " .--- "; break;
                case 'й': rez += " .--- "; break;

                case 'К': rez += " -.- "; break;
                case 'к': rez += " -.- "; break;

                case 'Л': rez += " .-.. "; break;
                case 'л': rez += " .-.. "; break;

                case 'М': rez += " -- "; break;
                case 'м': rez += " -- "; break;

                case 'Н': rez += " -. "; break;
                case 'н': rez += " -. "; break;

                case 'О': rez += " --- "; break;
                case 'о': rez += " --- "; break;

                case 'П': rez += " .--. "; break;
                case 'п': rez += " .--. "; break;

                case 'Р': rez += " .-. "; break;
                case 'р': rez += " .-. "; break;

                case 'С': rez += " ... "; break;
                case 'с': rez += " ... "; break;

                case 'Т': rez += " - "; break;
                case 'т': rez += " - "; break;

                case 'У': rez += " ..- "; break;
                case 'у': rez += " ..- "; break;

                case 'Ф': rez += " ..-. "; break;
                case 'ф': rez += " ..-. "; break;

                case 'Х': rez += " .... "; break;
                case 'х': rez += " .... "; break;

                case 'Ц': rez += " -.-. "; break;
                case 'ц': rez += " -.-. "; break;

                case 'Ч': rez += " ---. "; break;
                case 'ч': rez += " ---. "; break;

                case 'Ш': rez += " ---- "; break;
                case 'ш': rez += " ---- "; break;

                case 'Щ': rez += " --.- "; break;
                case 'щ': rez += " --.- "; break;

                case 'Ъ': rez += " --.-- "; break;
                case 'ъ': rez += " --.-- "; break;

                case 'Ы': rez += " -.-- "; break;
                case 'ы': rez += " -.-- "; break;

                case 'Ь': rez += " -..- "; break;
                case 'ь': rez += " -..- "; break;

                case 'Э': rez += " ..-.. "; break;
                case 'э': rez += " ..-.. "; break;

                case 'Ю': rez += " ..-- "; break;
                case 'ю': rez += " ..-- "; break;

                case 'Я': rez += " .-.- "; break;
                case 'я': rez += " .-.- "; break;

                case '0': rez += " ----- "; break;
                case '1': rez += " .---- "; break;
                case '2': rez += " ..--- "; break;
                case '3': rez += " ...-- "; break;
                case '4': rez += " ....- "; break;
                case '5': rez += " ..... "; break;
                case '6': rez += " -.... "; break;
                case '7': rez += " --... "; break;
                case '8': rez += " ---.. "; break;
                case '9': rez += " ----. "; break;

                case '.': rez += " .-.-.- "; break;
                case ',': rez += " --..-- "; break;
                case '!': rez += " -.-.-- "; break;
                case '?': rez += " ..--.. "; break;
                case '/': rez += " -..-. "; break;
                case '(': rez += " -.--. "; break;
                case ')': rez += " -.--.- "; break;
                case ';': rez += " -.-.-. "; break;
                case ':': rez += " ---... "; break;
                case '=': rez += " -...- "; break;
                case '+': rez += " .-.-. "; break;
                case '-': rez += " -....- "; break;
                case '_': rez += " ..--.- "; break;
                case '"': rez += " .-..-. "; break;
                case '$': rez += " ...-..- "; break;
                case '@': rez += " .--.-. "; break;
            }
        }
        return rez;
    }

    static string ru_DE_Morze(string text)
    {
        string rez = "";
        switch (text)
        {
            case "/": rez += " "; break;

            case ".-": rez += 'А'; break;
            case "-...": rez += 'Б'; break;
            case ".--": rez += 'В'; break;
            case "--.": rez += 'Г'; break;
            case "-..": rez += 'Д'; break;
            case ".": rez += 'Е'; break;
            case "...-": rez += 'Ж'; break;
            case "--..": rez += 'З'; break;
            case "..": rez += 'И'; break;
            case ".---": rez += 'Й'; break;
            case "-.-": rez += 'К'; break;
            case ".-..": rez += 'Л'; break;
            case "--": rez += 'М'; break;
            case "-.": rez += 'Н'; break;
            case "---": rez += 'О'; break;
            case ".--.": rez += 'П'; break;
            case ".-.": rez += 'Р'; break;
            case "...": rez += 'С'; break;
            case "-": rez += 'Т'; break;
            case "..-": rez += 'У'; break;
            case "..-.": rez += 'Ф'; break;
            case "....": rez += 'Х'; break;
            case "-.-.": rez += 'Ц'; break;
            case "---.": rez += 'Ч'; break;
            case "----": rez += 'Ш'; break;
            case "--.-": rez += 'Щ'; break;
            case "--.--": rez += 'Ъ'; break;
            case "-.---": rez += 'Ы'; break;
            case "-..-": rez += 'Ь'; break;
            case "..-..": rez += 'Э'; break;
            case "..--": rez += 'Ю'; break;
            case ".-.-": rez += 'Я'; break;

            case "-----": rez += '0'; break;
            case ".----": rez += '1'; break;
            case "..---": rez += '2'; break;
            case "...--": rez += '3'; break;
            case "....-": rez += '4'; break;
            case ".....": rez += '5'; break;
            case "-....": rez += '6'; break;
            case "--...": rez += '7'; break;
            case "---..": rez += '8'; break;
            case "----.": rez += '9'; break;

            case ".-.-.-": rez += '.'; break;
            case "--..--": rez += ','; break;
            case "-.-.--": rez += '!'; break;
            case "..--..": rez += '?'; break;
            case "-..-.": rez += '/'; break;
            case "-.--.": rez += '('; break;
            case "-.--.-": rez += ')'; break;
            case "-.-.-.": rez += ';'; break;
            case "---...": rez += ':'; break;
            case "-...-": rez += '='; break;
            case ".-.-.": rez += '+'; break;
            case "-....-": rez += '-'; break;
            case "..--.-": rez += '_'; break;
            case ".-..-.": rez += '"'; break;
            case "...-..-": rez += '$'; break;
            case ".--.-.": rez += '@'; break;
        }
        return rez;
    }

    static string en_EN_Morze(string text)
    {
        string rez = "";
        foreach (char ch in text)
        {
            if (Char.IsWhiteSpace(ch) == true)
            {
                rez += " / ";
            }
            switch (ch)
            {
                case 'A': rez += " .- "; break;
                case 'a': rez += " .- "; break;

                case 'B': rez += " -... "; break;
                case 'b': rez += " -... "; break;

                case 'C': rez += " -.-. "; break;
                case 'c': rez += " -.-. "; break;

                case 'D': rez += " -.. "; break;
                case 'd': rez += " -.. "; break;

                case 'E': rez += " . "; break;
                case 'e': rez += " . "; break;

                case 'F': rez += " ..-. "; break;
                case 'f': rez += " ..-. "; break;

                case 'G': rez += " --. "; break;
                case 'g': rez += " --. "; break;

                case 'H': rez += " .... "; break;
                case 'h': rez += " .... "; break;

                case 'I': rez += " .. "; break;
                case 'i': rez += " .. "; break;

                case 'J': rez += " .--- "; break;
                case 'j': rez += " .--- "; break;

                case 'K': rez += " -.- "; break;
                case 'k': rez += " -.- "; break;

                case 'L': rez += " .-.. "; break;
                case 'l': rez += " .-.. "; break;

                case 'M': rez += " -- "; break;
                case 'm': rez += " -- "; break;

                case 'N': rez += " -. "; break;
                case 'n': rez += " -. "; break;

                case 'O': rez += " --- "; break;
                case 'o': rez += " --- "; break;

                case 'P': rez += " .--. "; break;
                case 'p': rez += " .--. "; break;

                case 'Q': rez += " --.- "; break;
                case 'q': rez += " --.- "; break;

                case 'R': rez += " .-. "; break;
                case 'r': rez += " .-. "; break;

                case 'S': rez += " ... "; break;
                case 's': rez += " ... "; break;

                case 'T': rez += " - "; break;
                case 't': rez += " - "; break;

                case 'U': rez += " ..- "; break;
                case 'u': rez += " ..- "; break;

                case 'V': rez += " ...- "; break;
                case 'v': rez += " ...- "; break;

                case 'W': rez += " .-- "; break;
                case 'w': rez += " .-- "; break;

                case 'X': rez += " -..- "; break;
                case 'x': rez += " -..-"; break;

                case 'Y': rez += " -.-- "; break;
                case 'y': rez += " -.-- "; break;

                case 'Z': rez += " --.. "; break;
                case 'z': rez += " --.. "; break;

                case '0': rez += " ----- "; break;
                case '1': rez += " .---- "; break;
                case '2': rez += " ..--- "; break;
                case '3': rez += " ...-- "; break;
                case '4': rez += " ....- "; break;
                case '5': rez += " ..... "; break;
                case '6': rez += " -.... "; break;
                case '7': rez += " --... "; break;
                case '8': rez += " ---.. "; break;
                case '9': rez += " ----. "; break;

                case '.': rez += " .-.-.- "; break;
                case ',': rez += " --..-- "; break;
                case '!': rez += " -.-.-- "; break;
                case '?': rez += " ..--.. "; break;
                case '/': rez += " -..-. "; break;
                case '(': rez += " -.--. "; break;
                case ')': rez += " -.--.- "; break;
                case ';': rez += " -.-.-. "; break;
                case ':': rez += " ---... "; break;
                case '=': rez += " -...- "; break;
                case '+': rez += " .-.-. "; break;
                case '-': rez += " -....- "; break;
                case '_': rez += " ..--.- "; break;
                case '"': rez += " .-..-. "; break;
                case '$': rez += " ...-..- "; break;
                case '@': rez += " .--.-. "; break;
            }
        }
        return rez;
    }

    static string en_DE_Morze(string text)
    {
        string rez = "";
        switch (text)
        {
            case "/": rez += " "; break;

            case ".-": rez += 'A'; break;
            case "-...": rez += 'B'; break;
            case "-.-.": rez += 'C'; break;
            case "-..": rez += 'D'; break;
            case ".": rez += 'E'; break;
            case "..-.": rez += 'F'; break;
            case "--.": rez += 'G'; break;
            case "....": rez += 'H'; break;
            case "..": rez += 'I'; break;
            case ".---": rez += 'J'; break;
            case "-.-": rez += 'K'; break;
            case ".-..": rez += 'L'; break;
            case "--": rez += 'M'; break;
            case "-.": rez += 'N'; break;
            case "---": rez += 'O'; break;
            case ".--.": rez += 'P'; break;
            case "--.-": rez += 'Q'; break;
            case ".-.": rez += 'R'; break;
            case "...": rez += 'S'; break;
            case "-": rez += 'T'; break;
            case "..-": rez += 'U'; break;
            case "...-": rez += 'V'; break;
            case ".--": rez += 'W'; break;
            case "-..-": rez += 'X'; break;
            case "-.--": rez += 'Y'; break;
            case "--..": rez += 'Z'; break;

            case "-----": rez += '0'; break;
            case ".----": rez += '1'; break;
            case "..---": rez += '2'; break;
            case "...--": rez += '3'; break;
            case "....-": rez += '4'; break;
            case ".....": rez += '5'; break;
            case "-....": rez += '6'; break;
            case "--...": rez += '7'; break;
            case "---..": rez += '8'; break;
            case "----.": rez += '9'; break;

            case ".-.-.-": rez += '.'; break;
            case "--..--": rez += ','; break;
            case "-.-.--": rez += '!'; break;
            case "..--..": rez += '?'; break;
            case "-..-.": rez += '/'; break;
            case "-.--.": rez += '('; break;
            case "-.--.-": rez += ')'; break;
            case "-.-.-.": rez += ';'; break;
            case "---...": rez += ':'; break;
            case "-...-": rez += '='; break;
            case ".-.-.": rez += '+'; break;
            case "-....-": rez += '-'; break;
            case "..--.-": rez += '_'; break;
            case ".-..-.": rez += '"'; break;
            case "...-..-": rez += '$'; break;
            case ".--.-.": rez += '@'; break;
        }
        return rez;
    }
}
