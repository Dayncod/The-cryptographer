using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cipher_Selection : MonoBehaviour
{
    public Dropdown Select;

    public GameObject List;

    public GameObject Key;
    public GameObject Language;
    public GameObject EN_DE;

    public Text Conclusion;

    Vector2 EN_DE_LeftPosition = new Vector2(-176, 525);
    Vector2 EN_DE_CentrePosition = new Vector2(-5, 525);
    Vector2 EN_DE_default = new Vector2(140, 525);

    Vector2 Language_Select_LeftPosition = new Vector2(-204, 525);
    Vector2 Language_Select_default = new Vector2(-57, 525);

    static XOR_cipher xor;
    static Atbashcipher atbash;
    static Caesar_Cipher caesar;
    static Morse_Cipher morse;
    static A1Z26_Cipher a1z26;
    static The_Vigener_Cipher vigener;
    static Binary_Cipher binary;
    static Polybius_Square_Cipher polybius;

    static RectTransform language;
    static RectTransform en_de;


    private void Start()
    {
        xor = List.GetComponent<XOR_cipher>();
        atbash = List.GetComponent<Atbashcipher>();
        caesar = List.GetComponent<Caesar_Cipher>();
        morse = List.GetComponent<Morse_Cipher>();
        a1z26 = List.GetComponent<A1Z26_Cipher>();
        vigener = List.GetComponent<The_Vigener_Cipher>();
        binary = List.GetComponent<Binary_Cipher>();
        polybius = List.GetComponent<Polybius_Square_Cipher>();

        language = Language.GetComponent<RectTransform>();
        en_de = EN_DE.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Select.value == 0) //шифр XOR
        {
            xor.enabled = true;
            atbash.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(true);
            Language.SetActive(false);
            EN_DE.SetActive(false);
        }
        else if (Select.value == 1) //шифр Атбаша
        {
            atbash.enabled = true;
            xor.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(false);
            Language.SetActive(false);
            EN_DE.SetActive(false);

            Conclusion.color = Color.green;
        }
        else if (Select.value == 2) //шифр Цезаря
        {
            caesar.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(true);
            Language.SetActive(true);
            EN_DE.SetActive(true);

            language.anchoredPosition = Language_Select_default;
            en_de.anchoredPosition = EN_DE_default;
        }
        else if (Select.value == 3) //шифр Морзе
        {
            morse.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            caesar.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(false);
            Language.SetActive(true);
            EN_DE.SetActive(true);

            language.anchoredPosition = Language_Select_LeftPosition;
            en_de.anchoredPosition = EN_DE_CentrePosition;
        }
        else if (Select.value == 4) //шифр A1Z26
        {
            a1z26.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(false);
            Language.SetActive(false);
            EN_DE.SetActive(true);

            en_de.anchoredPosition = EN_DE_LeftPosition;
        }
        else if (Select.value == 5) //шифр Виженера
        {
            vigener.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            binary.enabled = false;

            Key.SetActive(true);
            Language.SetActive(true);
            EN_DE.SetActive(true);

            language.anchoredPosition = Language_Select_default;
            en_de.anchoredPosition = EN_DE_default;
        }
        else if (Select.value == 6) //Бинарный шифр
        {
            binary.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;

            Key.SetActive(false);
            Language.SetActive(false);
            EN_DE.SetActive(true);

            en_de.anchoredPosition = EN_DE_LeftPosition;
        }
        else if (Select.value == 7) //Квадрат Полибия
        {
            polybius.enabled = true;
            xor.enabled = false;
            atbash.enabled = false;
            caesar.enabled = false;
            morse.enabled = false;
            a1z26.enabled = false;
            vigener.enabled = false;
            binary.enabled = false;

            Key.SetActive(false);
            Language.SetActive(true);
            EN_DE.SetActive(true);

            language.anchoredPosition = Language_Select_LeftPosition;
            en_de.anchoredPosition = EN_DE_CentrePosition;
        }
    }
}
