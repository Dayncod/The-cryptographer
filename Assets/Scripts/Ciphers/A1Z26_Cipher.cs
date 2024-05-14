using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class A1Z26_Cipher : MonoBehaviour
{
    private const string Ru_alf = "àáâãäå¸æçèéêëìíîïğñòóôõö÷øùúûüışÿ";
    private const string Ru_AlfUpper = "ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß";

    public InputField Input;
    public Text Conclusion;

    public Dropdown EN_DE;

    void Update()
    {
        if (EN_DE.value == 0)
        {
            if (Input.text == " ")
            {
                Conclusion.text = " ";
            }
            else
            {
                Conclusion.text = Letter_To_Number(Input.text);
            }
        }          
        else if (EN_DE.value == 1)
        {
            if (Input.text == " ")
            {
                Conclusion.text = " ";
            }
            else
            {
                Conclusion.text = Number_To_Letter(Input.text);
            }   
        }
    }

    static string Letter_To_Number(string text)
    {
        string rez = "";
        string str = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (Ru_alf.Contains(text[i]))
            {
                if (i >= 1 && text[i - 1] == ' ')
                {
                    str = ((Ru_alf.IndexOf(text[i]) + 1).ToString());
                    rez += str;
                }
                else
                {
                    str = ('-' + (Ru_alf.IndexOf(text[i]) + 1).ToString());
                    rez += str;
                }
            }
            else if (Ru_AlfUpper.Contains(text[i]))
            {
                if (i >= 1 && text[i - 1] == ' ')
                {
                    str = ((Ru_AlfUpper.IndexOf(text[i]) + 1).ToString());
                    rez += str;
                }
                else
                {
                    str = ('-' + (Ru_AlfUpper.IndexOf(text[i]) + 1).ToString());
                    rez += str;
                }
            }
            else
            {
                rez += text[i];
            }
        }
        return rez.TrimStart('-');
    }

    static string Number_To_Letter(string text)
    {
        string rez = "";
        string[] words = Regex.Split(text, "( )");
        foreach (string word in words)
        {
            if (word == " ")
            {
                rez += " ";
            }
            else
            {
                string[] letters = Regex.Split(word, "(-)");
                foreach (string letter in letters)
                {
                    int value;
                    if (int.TryParse(letter, out value) == true)
                    {
                        int index = int.Parse(letter) - 1;
                        rez += Ru_AlfUpper[index];
                    }
                    else if (Regex.IsMatch(letter, @"^[0-9.,/!?$#¹@()_&;:<>{}|%]+$"))
                    {
                        int index = (int.Parse(string.Join("", letter.Where(c => char.IsDigit(c)))) - 1);
                        rez += Ru_AlfUpper[index] + String.Join("", letter.Where(c => char.IsPunctuation(c))) + " ";
                    }
                }
            } 
        }
        return rez;
    }
}
