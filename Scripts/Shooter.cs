using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private AudioSource BallAudioSource;
    public AudioClip ArremessoAudio;
    private Hole holeScore;
    public static Animator BallAnimation;

    private Vector3 offset;
    private Vector3 InitialTouchPosition, FinalTouchPosition, LastTouchPosition;

    private float zCord;
    private float XaxisForce, YaxisForce;
    public float speed = 1.5f;
    public static int numJogadas;

    public static bool takeBall = true;

    public void Awake()
    {
        numJogadas = 6;
        takeBall = true;

        BallAudioSource = GetComponent<AudioSource>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        BallAnimation = GetComponent<Animator>();

        BallAnimation.SetBool("Rotate", false);
    }

    public void Update()
    {
        if (numJogadas <= 0)
            StartCoroutine(Score(PlayerPrefs.GetString("login"), holeScore.score));

        if (FinalTouchPosition != Input.mousePosition)
        {
            LastTouchPosition = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        if (takeBall)
        {
            InitialTouchPosition = Input.mousePosition;

            zCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            offset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }

    void OnMouseDrag()
    {
        if (takeBall)
        {
            BallAnimation.SetBool("Rotate", true);

            if (BallAnimation.GetBool("Rotate") == true)
                BallAnimation.Play("Ball");

            transform.position = GetMouseAsWorldPoint() + offset;
        }
    }

    void OnMouseUp()
    {
        if (takeBall)
        {
            BallAudioSource.PlayOneShot(ArremessoAudio);

            GetComponent<Rigidbody>().freezeRotation = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;

            FinalTouchPosition = Input.mousePosition;

            XaxisForce = FinalTouchPosition.x - LastTouchPosition.x;
            YaxisForce = FinalTouchPosition.y - LastTouchPosition.y;

            Vector3 arremesso = new Vector3(YaxisForce, YaxisForce, -XaxisForce);

            if (Hole.acertos == 1 || Hole.acertos == 4)
                arremesso = Quaternion.Euler(0, 90 - Camera.main.transform.rotation.y * 360, 0) * arremesso;
            else if (Hole.acertos == 2 || Hole.acertos == 5)
                arremesso = Quaternion.Euler(0, 90 + Camera.main.transform.rotation.y * 360, 0) * arremesso;

            GetComponent<Rigidbody>().AddForce(arremesso * speed);


        }

        takeBall = false;
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = zCord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    IEnumerator Score(string namelo, int pontos)
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "SELECT pontos FROM player WHERE login = '" + namelo + "'");
        var w = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", wwwf);

        yield return w.SendWebRequest();
        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            Players pontosPlayer = JsonUtility.FromJson<Players>(w.downloadHandler.text);


            if (pontos > pontosPlayer.objetos[0].pontos)
            {
                wwwf = new WWWForm();
                wwwf.AddField("SQL", "UPDATE player SET pontos = " + pontos + " WHERE login = '" + namelo + "'");
                var w2 = UnityWebRequest.Post("http://fatecnsn.mygamesonline.org/", wwwf);
                yield return w2.SendWebRequest();
                if (w2.isNetworkError || w2.isHttpError)
                {
                    Debug.Log(w2.error);
                }
            }
        }
    }
}