using UnityEngine;
using UnityEngine.UI;

public class ScrollPanels : MonoBehaviour
{
    public GameObject Ciphers_Panel;
    public GameObject Passwords_Panel;
    public GameObject QR_Panel;

    public Button Cipher_Button;
    public Button Passwords_Button;
    public Button QR_Button;

    public Animator Ciphers_Animator;
    public Animator Passwords_Animator;
    public Animator QR_Animator;

    [SerializeField] private bool OpenCipher = true;
    [SerializeField] private bool OpenPasswords = false;
    [SerializeField] private bool OpenQR = false;

    public void CipherActive()
    {
        if (OpenQR == true)
        {
            OpenQR = false;

            Ciphers_Animator.Play("CipherToRight");
            QR_Animator.Play("QRRightOverEdge");

            OpenCipher = true;
        }
        else if (OpenPasswords == true)
        {
            OpenPasswords = false;

            Ciphers_Animator.Play("CipherToRight");
            Passwords_Animator.Play("PasswordToRight");

            OpenCipher = true;
        }
    }

    public void PasswordActive()
    {
        if (OpenQR == true)
        {
            OpenQR = false;

            Passwords_Animator.Play("PasswordToLeft");
            QR_Animator.Play("QRLeftOverEdge");

            OpenPasswords = true;
        }
        else if (OpenCipher == true)
        {
            OpenCipher = false;

            Passwords_Animator.Play("PasswordToLeft");
            Ciphers_Animator.Play("CipherToLeft");

            OpenPasswords = true;
        }
    }

    public void QRActive()
    {
        if (OpenCipher == true)
        {
            OpenCipher = false;
            
            QR_Animator.Play("QRLeftToCenter");
            Ciphers_Animator.Play("CipherToLeft");

            OpenQR = true;
        }
        else if (OpenPasswords == true)
        {
            OpenPasswords = false;

            QR_Animator.Play("QRRightToCenter");
            Passwords_Animator.Play("PasswordToRight");

            OpenQR = true;
        }
    }

}
