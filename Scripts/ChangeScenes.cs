using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{

    public void CarregarFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void CarregarFase2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void CarregarFase3()
    {
        SceneManager.LoadScene("Fase3");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Logout()
    {
        SceneManager.LoadScene("Login");
    }

    public void carregarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void carregarHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadSounds()
    {
        SceneManager.LoadScene("Sounds");
    }
}