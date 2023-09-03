using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class AudioScript
{

    public static AudioSource audio;
    public static void Init()
    {
        audio = GameObject.Find("Sound").GetComponent<AudioSource>();
    }

    public static void play(AudioClip pAudio)  {
        audio.PlayOneShot(pAudio);

    }
}
