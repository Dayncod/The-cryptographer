using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject Setting_Panel;
    public GameObject Title;
    public void On_Clic()
    {
        if (!Setting_Panel.activeInHierarchy)
        {
            Setting_Panel.SetActive(true);
            Title.SetActive(false);
        }
        else if (Setting_Panel.activeInHierarchy)
        {
            Setting_Panel.SetActive(false);
            Title.SetActive(true);
        }

    }
}
