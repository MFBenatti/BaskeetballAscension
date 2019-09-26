using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignObjLogin : MonoBehaviour
{
    public GameObject mainMenuLogin;
    public GameObject mainMenuSignIn;

    public Text answerMessage;

    private void Awake()
    {
        mainMenuLogin.transform.position = new Vector2(Screen.width / 2, Screen.height / 2 + Screen.height / 10);
        mainMenuSignIn.transform.position = new Vector2(Screen.width / 2, Screen.height / 2 + Screen.height / 10);

        answerMessage.transform.position = new Vector2(Screen.width / 2, Screen.height / 2 - Screen.height / 2);
        answerMessage.rectTransform.sizeDelta = new Vector2(300, 200);
        answerMessage.fontStyle = FontStyle.Normal;
        answerMessage.fontSize = 13;
        answerMessage.alignment = TextAnchor.UpperCenter;
    }

    public void Start()
    {
        DesativarSingInAtivarLogin();
    }

    public void DesativarSingInAtivarLogin()
    {
        mainMenuLogin.gameObject.SetActive(true);
        mainMenuSignIn.gameObject.SetActive(false);
        answerMessage.text = "";
    }

    public void AtivarSingInDesativarLogin()
    {
        mainMenuLogin.gameObject.SetActive(false);
        mainMenuSignIn.gameObject.SetActive(true);
        answerMessage.text = "";
    }
}
