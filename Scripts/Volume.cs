using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer am;

    public void Awake()
    {
       // imagePause.enabled = false;
       // imagePlay.enabled = true;
    }

    public void controlaVolumeSFX(float volume)
    {
        am.SetFloat("volumeSFX", volume);
    }

    public void controlaVolumeMusica(float volume)
    {
        am.SetFloat("volumeMusica", volume);
    }
}

