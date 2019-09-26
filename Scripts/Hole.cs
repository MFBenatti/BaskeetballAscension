using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    private Animator HoleAnimator;
    private AudioSource HoleAudioSource;
    public AudioClip HoleAudioClip;

    public Text m_Score;
    public int score = 0;

    private bool returnBall = false;
    private float countTrigger = 2.5f;
    public static int acertos = 0;

    public void Awake()
    {
        HoleAudioSource = GetComponent<AudioSource>();
        HoleAnimator = GetComponent<Animator>();
        HoleAnimator.SetBool("HoleDo", false);
    }

    public void Start()
    {
        acertos = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            HoleAnimator.SetBool("HoleDo", true);

            GameObject particle = GameObject.FindGameObjectWithTag("Particle");
            particle.GetComponent<ParticleSystem>().Play();

            HoleAudioSource.PlayOneShot(HoleAudioClip);

            GameObject f = GameObject.Find("Floor");
            f.GetComponent<BoxCollider>().isTrigger = false;

            acertos++;
            score = score + (int)Timer.CountDown;
            m_Score.text = "Score: " + score.ToString();

            returnBall = true;

            Shooter.numJogadas--;
            HUD.cesta = true;
            HUD.primeiroArremesso = true;
        }
    }

    private void Update()
    {
        if(returnBall)
        {
            countTrigger -= Time.deltaTime;

            if(countTrigger <= 0)
            {
                GameObject ball = GameObject.Find("Ball");

                if (acertos == 0 || acertos == 3)
                {
                    Camera.main.transform.position = new Vector3(-25f, 11.84f, -80.2f);
                    Camera.main.transform.rotation = Quaternion.Euler(5, 90, 0);
                    Camera.main.fieldOfView = 23;
                    
                    ball.transform.position = new Vector3(14f, 3.5f, -80.2f);
                    //ball.transform.position = new Vector3(24f, 11f, -80.2f);
                    ball.transform.rotation = Quaternion.identity;
                }
                else if(acertos == 1 || acertos == 4)
                {
                    Camera.main.transform.position = new Vector3(8f, 8f, -97f);
                    Camera.main.transform.rotation = Quaternion.Euler(5, 45, 0);
                    Camera.main.fieldOfView = 55;

                    ball.transform.position = new Vector3(16f, 3.5f, -89f);
                    //ball.transform.position = new Vector3(24f, 11f, -80.2f);
                    ball.transform.rotation = Quaternion.identity;
                }
                else if(acertos == 2 || acertos == 5)
                {
                    Camera.main.transform.position = new Vector3(8f, 8f, -63f);
                    Camera.main.transform.rotation = Quaternion.Euler(5, 135, 0);
                    Camera.main.fieldOfView = 55;

                    ball.transform.position = new Vector3(16f, 3.5f, -71f);
                    //ball.transform.position = new Vector3(24f, 11f, -80.2f);
                    ball.transform.rotation = Quaternion.identity;
                }
                


                ball.GetComponent<Rigidbody>().freezeRotation = true;
                ball.GetComponent<Rigidbody>().isKinematic = true;
                ball.GetComponent<Rigidbody>().useGravity = false;

                GameObject f = GameObject.Find("Floor");
                f.GetComponent<BoxCollider>().isTrigger = true;

                returnBall = false;
                countTrigger = 2.5f;

                Shooter.takeBall = true;
                Shooter.BallAnimation.SetBool("Rotate", false);
                HoleAnimator.SetBool("HoleDo", false);
            }
        }
    }
}
