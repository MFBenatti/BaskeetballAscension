using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignTexts : MonoBehaviour
{
    public Text nameGame;
    public Text companyName;
    public Text buttonText;
    public Button pressStart;

    public void Awake()
    {
        nameGame.text = "BASKETBALL" + System.Environment.NewLine + "ASCENSION";
        nameGame.transform.position = new Vector2(Screen.width/2, Screen.height/2 + Screen.height/6.0f);
        nameGame.rectTransform.sizeDelta = new Vector2(500, 150);
        nameGame.fontStyle = FontStyle.Normal;
        nameGame.fontSize = 180;
        nameGame.lineSpacing = 0.75f;
        nameGame.alignment = TextAnchor.MiddleCenter;

        companyName.text = "© 2019 NSN. All rights reserved.";
        companyName.transform.position = new Vector2(Screen.width/2, Screen.height/2 - Screen.height/2);
        companyName.rectTransform.sizeDelta = new Vector2(500, 60);
        companyName.fontStyle = FontStyle.Normal;
        companyName.fontSize = 50;
        companyName.alignment = TextAnchor.MiddleCenter;

        buttonText.text = "TOUCH TO START";
        pressStart.transform.position = new Vector2(Screen.width/2, Screen.height/2 - Screen.height/6.0f);
        buttonText.rectTransform.sizeDelta = new Vector2(500, 60);
        buttonText.fontStyle = FontStyle.Normal;
        buttonText.fontSize = 50;
        buttonText.alignment = TextAnchor.MiddleCenter;
    }
}
