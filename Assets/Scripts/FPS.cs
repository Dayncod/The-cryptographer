using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public Text FPSlabel;

    
    void Update()
    {
        float fps = 1.0f / Time.deltaTime;
        FPSlabel.text = $"FPS: {Mathf.Ceil(fps)}";
    }
}
