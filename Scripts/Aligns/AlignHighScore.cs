using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignHighScore : MonoBehaviour
{
    public GameObject highScore;

    public void Awake()
    {
        gameObject.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
}
