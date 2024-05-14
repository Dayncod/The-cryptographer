using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyPassword : MonoBehaviour
{
    public Text Password;

    public void onClickCopyPass()
    {
        GUIUtility.systemCopyBuffer = Password.text;
        print("Пароль скопирован");
    }
}
