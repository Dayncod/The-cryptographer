using UnityEngine;
using UnityEngine.UI;

public class RandPass : MonoBehaviour
{
    public Toggle Toggle_Numbers;
    public Toggle Toggle_SpecialCharacters;
    public Toggle Toggle_UppercaseLetters;
    public Toggle Toggle_LowercaseLetters;

    public InputField Size;

    public Button Generate;

    public Text[] Passwords = new Text[10];

    public GameObject Generated_variants;

    const string Numbers = "0123456789";
    const string SpecialCharacters = "!#$%&()*+./:;=>?@[]^`{|}~'|";
    const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";


    public void onClickGeneratePass()
    {
        string RandPass = "";

        if (Size.text == "")
        {
            return;
        }
        else
        {
            if (Generated_variants.activeInHierarchy == false)
            {
                Generated_variants.SetActive(true);
            }

            System.Random rand = new System.Random();

            if (Toggle_Numbers.isOn)
            {
                RandPass += Numbers;
            }

            if (Toggle_SpecialCharacters.isOn)
            {
                RandPass += SpecialCharacters;
            }

            if (Toggle_UppercaseLetters.isOn)
            {
                RandPass += UppercaseLetters;
            }

            if (Toggle_LowercaseLetters.isOn)
            {
                RandPass += LowercaseLetters;
            }

            if (RandPass == "")
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                string Password = "";

                for (int j = 0; j < int.Parse(Size.text); j++)
                {
                    int randIndexChar = rand.Next(RandPass.Length);
                    char randChar = RandPass[randIndexChar];
                    Password += randChar;
                }
                Passwords[i].text = Password;
            }
        }
    }
}
