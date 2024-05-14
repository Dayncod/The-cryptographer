using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Copy_to_Clipboard : MonoBehaviour
{
    public Text Conclusion;
    public GameObject Massage_Panel_To_Copy;
    public Text Text_Massage;

    public void Copy()
    {
        if (Conclusion.text != "")
        {
            StartCoroutine(Massage_Panel());
            CopyToClipboard(Conclusion.text);
        }
        Debug.Log("Копирование");
    }

    static void CopyToClipboard(string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }

    IEnumerator Massage_Panel()
    {
        if (!Massage_Panel_To_Copy.activeInHierarchy)
        {
            Massage_Panel_To_Copy.SetActive(true);

            Text_Massage.GetComponent<Text>().color = new Color(1f, 1f, 0, 1f);
            float alpha = 1f;

            while (Text_Massage.GetComponent<Text>().color.a >= 0)
            {
                alpha -= 0.03f;
                Text_Massage.GetComponent<Text>().color = new Color(1f, 1f, 0, alpha);
                yield return new WaitForSeconds(0.1f);

                if (Text_Massage.GetComponent<Text>().color.a <= 0)
                {
                    Massage_Panel_To_Copy.SetActive(false);
                }
            }
        }
    }
}

