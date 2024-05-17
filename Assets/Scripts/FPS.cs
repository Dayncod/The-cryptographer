using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text FPSlabel;

    
    void Update()
    {
        float fps = 0;
        fps = (int)(1.0f /Time.unscaledDeltaTime);
        FPSlabel.text = $"FPS: {fps}";
    }
}
