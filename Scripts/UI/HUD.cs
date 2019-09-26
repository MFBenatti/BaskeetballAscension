using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject canvasGameOver;
    public GameObject canvasNextStage;
    public GameObject lifes;
    public GameObject[] countLifes = new GameObject[6];

    public Text scoreText;
    public Text timeText;
    public Text stageText;

    public static bool cesta;
    public static bool primeiroArremesso;

    private float countCanvas;

    private void Awake()
    {
        primeiroArremesso = false;
        countCanvas = 1f;

        Time.timeScale = 1.0f;

        canvasGameOver.SetActive(false);
        canvasNextStage.SetActive(false);
        Lost.vidas = 6;
        
        pauseButton.transform.position = new Vector2((Screen.width / 2 + Screen.width / 2) - 10, (Screen.height / 2 - Screen.height / 2) + 10);

        scoreText.transform.position = new Vector2(0 + scoreText.GetComponent<RectTransform>().sizeDelta.x / 2 - scoreText.GetComponent<RectTransform>().sizeDelta.x / 2,
            Screen.height / 2 + Screen.height / 2);
        scoreText.fontStyle = FontStyle.Italic;
        scoreText.alignment = TextAnchor.LowerLeft;
        scoreText.fontSize = 90;
        scoreText.rectTransform.sizeDelta = new Vector2(500, 110);

        lifes.transform.position = new Vector2(Screen.width / 2 - Screen.width / 2.2f, Screen.height / 2 + Screen.height / 2.9f);

        stageText.transform.position = new Vector2(Screen.width / 2 + Screen.width / 2, Screen.height / 2 + Screen.height / 2);
        stageText.fontStyle = FontStyle.Italic;
        stageText.alignment = TextAnchor.LowerLeft;
        stageText.fontSize = 90;
        stageText.rectTransform.sizeDelta = new Vector2(360, 110);
        stageText.text = "STAGE 1";

        timeText.transform.position = new Vector2(Screen.width / 2 - Screen.width / 2, Screen.height / 2 - Screen.height / 2);
        timeText.fontStyle = FontStyle.Normal;
        timeText.alignment = TextAnchor.MiddleLeft;
        timeText.fontSize = 150;
        timeText.rectTransform.sizeDelta = new Vector2(350, 170);

        countLifes[0].gameObject.SetActive(true);
        countLifes[1].gameObject.SetActive(true);
        countLifes[2].gameObject.SetActive(true);
        countLifes[3].gameObject.SetActive(true);
        countLifes[4].gameObject.SetActive(true);
        countLifes[5].gameObject.SetActive(true);
    }

    private void Update()
    {
        timeText.text = Timer.CountDown.ToString();

        if(primeiroArremesso)
        {
            if (!cesta)
                countLifes[Shooter.numJogadas].GetComponent<Image>().color = Color.red;
            else if (cesta)
                countLifes[Shooter.numJogadas].GetComponent<Image>().color = Color.green;
        }

        if (Timer.CountDown <= 0)
        {
            Shooter.takeBall = false;
            countCanvas -= Time.deltaTime;

            if (Hole.acertos >= 3 && countCanvas <= 0)
            {
                canvasNextStage.SetActive(true);
                timeText.text = "00:00";
                Time.timeScale = 0.0f;
            }
            else if(Hole.acertos < 3 && countCanvas <= 0)
            {
                canvasGameOver.SetActive(true);
                timeText.text = "00:00";
                Time.timeScale = 0.0f;
            }
        }
        else if(Shooter.numJogadas <= 0)
        {
            Shooter.takeBall = false;
            countCanvas -= Time.deltaTime;

            if (Hole.acertos >= 3 && countCanvas <= 0)
            {
                canvasNextStage.SetActive(true);
                timeText.text = "00:00";
                Time.timeScale = 0.0f;
            }
            else if (Hole.acertos < 3 && countCanvas <= 0)
            {
                canvasGameOver.SetActive(true);
                timeText.text = "00:00";
                Time.timeScale = 0.0f;
            }
        }
    }
}
