using UnityEngine;
using UnityEngine.UI;

public class Save_Output_Type : MonoBehaviour
{
    public Dropdown Dropdown;
    public Text Label_Selection;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveSelection"))
        {
            Dropdown.value = PlayerPrefs.GetInt("SaveSelection");
            Debug.Log("��������� ���������: " + PlayerPrefs.GetString("SaveSelection") + " | " + Label_Selection.text);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("SaveSelection", Dropdown.value);
        PlayerPrefs.Save();
        Debug.Log("��������� ���������: " + Label_Selection.text);
    }
}
