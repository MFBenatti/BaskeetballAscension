using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lost : MonoBehaviour
{
    public static int vidas = 6;
    private float counterTrigger = 2.0f;

    public void Start()
    {
        vidas = 6;
    }

    private void OnTriggerStay(Collider other)
    {
        counterTrigger -= Time.deltaTime; 

        if (other.CompareTag("Ball") && counterTrigger <= 0)
        {
            vidas--;
            GameObject ball = GameObject.Find("Ball");

            if (Hole.acertos == 0 || Hole.acertos == 3)
            {
                Camera.main.transform.position = new Vector3(-25f, 11.84f, -80.2f);
                Camera.main.transform.rotation = Quaternion.Euler(5, 90, 0);
                Camera.main.fieldOfView = 23;

                ball.transform.position = new Vector3(14f, 3.5f, -80.2f);
                //ball.transform.position = new Vector3(24f, 11f, -80.2f);
                ball.transform.rotation = Quaternion.identity;
            }
            else if (Hole.acertos == 1 || Hole.acertos == 4)
            {
                Camera.main.transform.position = new Vector3(8f, 8f, -97f);
                Camera.main.transform.rotation = Quaternion.Euler(5, 45, 0);
                Camera.main.fieldOfView = 55;

                ball.transform.position = new Vector3(16f, 3.5f, -89f);
                //ball.transform.position = new Vector3(24f, 11f, -80.2f);
                ball.transform.rotation = Quaternion.identity;
            }
            else if (Hole.acertos == 2 || Hole.acertos == 5)
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
            counterTrigger = 2.0f;

            Shooter.takeBall = true;
            Shooter.BallAnimation.SetBool("Rotate", false);

            Shooter.numJogadas--;
            HUD.cesta = false;
            HUD.primeiroArremesso = true;
        }
    }
}
