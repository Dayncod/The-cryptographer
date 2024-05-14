using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clearing : MonoBehaviour
{
    public InputField Input;
    public InputField Key;
    public void On_Clic()
    {
        Input.text = "";
        Key.text = "";
    }
}
