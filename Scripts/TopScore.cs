using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public Text nome;
    public Text points;

    void Start()
    {
        Top10Scores();
    }

    IEnumerator Score()
    {
        WWWForm web = new WWWForm();
        web.AddField("SQL", "SELECT login, pontos FROM player ORDER BY pontos DESC LIMIT 10");

        UnityWebRequest uwr;
        uwr = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", web);

        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Players pcContainer = JsonUtility.FromJson<Players>(uwr.downloadHandler.text);

            if (pcContainer.objetos.Length > 0)
            {
                foreach (Players.Player item in pcContainer.objetos)
                {
                    nome.text += item.login + "\n";
                    points.text += item.pontos + "  \n";
                }
            }
        }
    }

    public void Top10Scores()
    {
        StartCoroutine(Score());
    }
}
