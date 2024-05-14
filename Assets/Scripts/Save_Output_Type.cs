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
            Debug.Log("Сохранеие загружено: " + PlayerPrefs.GetString("SaveSelection") + " | " + Label_Selection.text);
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("SaveSelection", Dropdown.value);
        PlayerPrefs.Save();
        Debug.Log("Сохранеие сохранено: " + Label_Selection.text);
    }
}
