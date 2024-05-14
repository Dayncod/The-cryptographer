using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class The_Vigener_Cipher : MonoBehaviour
{
    private const string Ru_alf = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    int sizeRu = Ru_alf.Length;
    private const string En_alf = "abcdefghijklmnopqrstuvwxyz";
    int sizeEn = En_alf.Length;

    public InputField Input;
    public Text Conclusion;

    public InputField Key;
    public Dropdown EN_DE;
    public Dropdown Language;

    static Image Key_Color;

    private void Start()
    {
        Key_Color = Key.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.text == "")
        {
            Key_Color.color = Color.green;
            Conclusion.color = Color.green;

            Conclusion.text = ""; 
        }
        else 
        {
            Key_Color.color = Color.green;
            Conclusion.color = Color.green;

            if (Language.value == 0)
            {
                if (EN_DE.value == 0)
                {
                    Conclusion.text = En_Vigener_Cipher(Input.text, Key.text, Ru_alf);
                }
                else if (EN_DE.value == 1)
                {
                    Conclusion.text = De_Vigener_Cipher(Input.text, Key.text, Ru_alf);
                }
            }
            else if (Language.value == 1)
            {
                if (EN_DE.value == 0)
                {
                    Conclusion.text = En_Vigener_Cipher(Input.text, Key.text, En_alf);
                }
                else if (EN_DE.value == 1)
                {
                    Conclusion.text = De_Vigener_Cipher(Input.text, Key.text, En_alf);
                }
            }
        }
    }

    string En_Vigener_Cipher(string B_text, string B_Key, string Alf) //метод шифрования(вводимый текст, ключ)
    {
        string cj = ""; //объявляем переменную, в которую будем записывать преобразованный символ

        string text = B_text.ToLower(); //преобразуем все буквы вводимого текста в строчные и сохраняем в отдельную переменную
        string Key = B_Key.ToLower(); //преобразуем все буквы ключа в строчные и сохраняем в отдельную переменную

        int n = Alf.Length;

        if (Key == "")
        {
            Key_Color.color = Color.red;
            Conclusion.color = Color.red;
            return "Введите ключ";
        }
        else
        {
            Key_Color.color = Color.green;
            Conclusion.color = Color.green;
        }

        int i = 0; //счётчик ключа

        foreach (char item in text) //основной цикл, которые каждую иттерацию шифрует один символ
        {
            char k = Key[i];  //активный символ ключа

            if (!Alf.Contains(k))
            {
                Key_Color.color = Color.red;
                Conclusion.color = Color.red;
                return "Ошибка ключа";
            }
            else
            {
                Key_Color.color = Color.green;
                Conclusion.color = Color.green;
            }

            if (!Alf.Contains(item)) //проверяем символ на отсутствие в алфавите
            {
                cj += item; //и если true, то возвращаем осходный символ
                continue;
            }
            else
            {
                int mj = Alf.IndexOf(item); //находим индекс символа текста
                int kj = Alf.IndexOf(k); //находим индекс символа ключа

                int c = (mj + kj) % n + 1; //производим шифрование по готовой формуле

                if (c == n) //проверяем, если индекс символа в алфавите = 33
                {
                    cj += Alf[0]; //то меняем его на 0, т.е. сохраняем букву "а"
                }
                else
                {
                    cj += Alf[c]; //иначе сохраняем букву под найденым индексом
                }

                k = Key[i++]; //прибовляем 1 к счётчику ключа, что бы в следующей иттерации шифровать символ следующим символом ключа

                if (i >= Key.Length) //проверяем, если счётчик больше либо равен длине ключа и если true
                {
                    i = 0; //то обнуляем счётчик
                    k = Key[i]; 
                }
            }
        }
        return cj; //выводим зашифрованный символ
    }

    string De_Vigener_Cipher(string B_text, string B_Key, string Alf)
    {
        string cj = ""; 

        string text = B_text.ToLower();
        string Key = B_Key.ToLower();

        int n = Alf.Length;

        if (Key == "")
        {
            Key_Color.color = Color.red;
            Conclusion.color = Color.red;
            return "Введите ключ";
        }
        else
        {
            Key_Color.color = Color.green;
            Conclusion.color = Color.green;
        }

        int i = 0;

        foreach (char item in text)
        {
            char k = Key[i];

            if (!Alf.Contains(item))
            {
                cj += item;
                continue;
            }
            else
            {
                int mj = Alf.IndexOf(item);
                int kj = Alf.IndexOf(k);

                int c = (mj + n - kj) % n - 1;

                if (c == -1)
                {
                    cj += Alf[0];
                }
                else
                {
                    cj += Alf[c];
                }

                k = Key[i++];

                if (i >= Key.Length) 
                {
                    i = 0;
                    k = Key[i];
                }
            }
        }
        return cj;
    }
}
