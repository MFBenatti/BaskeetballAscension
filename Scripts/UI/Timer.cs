using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float MaxTime = 60.0f;

    [SerializeField]
    public static float CountDown = 0;

    void Start ()
    {
        CountDown = MaxTime;		
	}
	
	void Update ()
    {
        CountDown -= Time.deltaTime;
    }
}
