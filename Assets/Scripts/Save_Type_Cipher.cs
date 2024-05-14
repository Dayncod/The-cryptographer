using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_Type_Cipher : MonoBehaviour
{
    public Dropdown Select;
    public Text Label;

    void Start()
    {
        if (PlayerPrefs.HasKey("Save_Cipher"))
        {
            Select.value = PlayerPrefs.GetInt("Save_Cipher");
            Debug.Log("Загружено сохранение со шрифтом: " + Label.text);
        }
    }

    public void Save_Cipher()
    {
        PlayerPrefs.SetInt("Save_Cipher", Select.value);
        PlayerPrefs.Save();
        Debug.Log("Сохранёт шифр: " + Label.text);
    }
}
