using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumChars : MonoBehaviour
{
    public InputField Input;
    public Text Input_Text;

    public GameObject Output_Panel;
    public Text Conclusion;

    public Text Num;

    static RectTransform ConclusionBottom;

    static int valueSize;

    private void Start()
    {
        ConclusionBottom = Output_Panel.GetComponent<RectTransform>();

        valueSize = Conclusion.text.Length;

        print(ConclusionBottom.offsetMin.y);
    }

    private void Update()
    {
        int inN;
        inN = Input.text.Length;

        int outN;
        outN = Conclusion.text.Length;

        Num.text = $"{inN} : {outN}";

        Increase_Input(Input_Text, inN);

        Expand_output(outN);
    }

    static void Increase_Input(Text Input_Text, int inputN)
    {
        if (inputN >= 232)
        {
            Input_Text.fontSize = 22;
        }
        else
        {
            Input_Text.fontSize = 30;
        }
    }

    static void Expand_output(int outN)
    {
        if (outN < 360)
        {
            if (ConclusionBottom.offsetMin.y >= 45)
            {
                if (ConclusionBottom.offsetMin.y < 335)
                {
                    ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y + 2);
                }
            }
        }
        if (outN >= 360 && outN < 495)
        {
            if (ConclusionBottom.offsetMin.y > 240)
            {
                ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y - 2);
            }
            else if (ConclusionBottom.offsetMin.y >= 144)
            {
                if (ConclusionBottom.offsetMin.y < 239)
                {
                    ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y + 2);
                }
            }
        }
        if (outN >= 495 && outN < 585)
        {
            if (ConclusionBottom.offsetMin.y > 145)
            {
                ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y - 2);
            }
            else if (ConclusionBottom.offsetMin.y >= 50)
            {
                if (ConclusionBottom.offsetMin.y < 144)
                {
                    ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y + 2);
                }
            }
        }
        if ((outN >= 585 && outN < 720))
        {
            if (ConclusionBottom.offsetMin.y > 50)
            {
                ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y - 2);
            }
        }
        if (outN >= 720)
        {
            if (ConclusionBottom.offsetMin.y >= 50)
            {
                ConclusionBottom.offsetMin = new Vector2(ConclusionBottom.offsetMin.x, ConclusionBottom.offsetMin.y - 3);
            }
        }
    }
}
