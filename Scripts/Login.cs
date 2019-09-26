using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class Login : MonoBehaviour
{

    public InputField namelogin;
    public InputField nameregister;
    public InputField pwdlogin;
    public InputField pwdregister;
    public InputField confsenha;
    public Text message;


    IEnumerator pegarInfo(string namelo)
    {

        WWWForm web = new WWWForm();
        web.AddField("SQL", "SELECT * FROM player WHERE login = '" + namelo + "'");

        UnityWebRequest uwr;
        uwr = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", web);

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Players playersCont;
            playersCont = JsonUtility.FromJson<Players>(uwr.downloadHandler.text);

            if ((playersCont.objetos.Length) == 0)
            {
                if (pwdregister.text != "" && confsenha.text != "")
                {
                    if (conferirSenha())
                    {
                        WWWForm webb = new WWWForm();
                        webb.AddField("SQL", "INSERT INTO player (login, password) VALUES ('" + namelo + "',SHA1('" + pwdregister.text + "'))");

                        UnityWebRequest uwwr;
                        uwwr = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", webb);

                        yield return uwwr.SendWebRequest();

                        if (uwwr.isNetworkError || uwwr.isHttpError)
                        {
                            Debug.Log(uwwr.error);
                        }
                        message.text = "Registration successfully Complete!";
                        nameregister.text = "";
                        pwdregister.text = "";
                        confsenha.text = "";

                    }
                    else
                    {
                        message.text = "Unequal Passwords... Please try again!";
                        pwdregister.text = "";
                        confsenha.text = "";
                    }
                }
                else
                {
                    message.text = "Please fill in the data correctly... try again!";
                    pwdregister.text = "";
                    confsenha.text = "";
                }
            }
            else
            {
                message.text = "User already registered... Please try again!";
                nameregister.text = "";
                pwdregister.text = "";
                confsenha.text = "";
            }
        }
    }


    public void register()
    {
        StartCoroutine(pegarInfo(nameregister.text));
    }


    public bool conferirSenha()
    {
        if (pwdregister.text == confsenha.text)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator pegarLogin(string namelo, string pwd)
    {

        if (namelo == "" && pwd == "")
        {
            message.text = "Please fill in the data correctly... try again!";
            namelogin.text = "";
            pwdlogin.text = "";
        }
        else
        {
            WWWForm web = new WWWForm();
            web.AddField("SQL", "SELECT * FROM player WHERE login = '" + namelo + "' AND password = SHA1('" + pwd + "')");

            UnityWebRequest uwr;
            uwr = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", web);

            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Players playersCont;
                playersCont = JsonUtility.FromJson<Players>(uwr.downloadHandler.text);

                if ((playersCont.objetos.Length) == 1)
                {
                    message.text = "Login done successfully!";
                    PlayerPrefs.SetString("login", namelo);
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    message.text = "User or password incorrect... Please try again!";
                    namelogin.text = "";
                    pwdlogin.text = "";
                }
            }
        }
    }


    public void login()
    {
        StartCoroutine(pegarLogin(namelogin.text, pwdlogin.text));

    }

}