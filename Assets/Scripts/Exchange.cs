using UnityEngine;
using UnityEngine.UI;

public class Exchange : MonoBehaviour
{
    public InputField Input;
    public Text Conclusion;

    public GameObject EN_DE;
    public Dropdown EN_DE_values;

    public void On_Clic()
    {
        if (EN_DE.activeInHierarchy == true)
        {
            if (EN_DE_values.value == 0)
            {
                EN_DE_values.value = 1;
                Input.text = Conclusion.text;
            }
            else if (EN_DE_values.value == 1)
            {
                EN_DE_values.value = 0;
                Input.text = Conclusion.text;
            }
        }
        else
        {
            Input.text = Conclusion.text;
        }
    }
}
