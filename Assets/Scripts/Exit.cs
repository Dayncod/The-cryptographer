using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void On_Clic()
    {
        Application.Quit();
        print("Выход");
        Debug.Log("Выход");
    }
}
