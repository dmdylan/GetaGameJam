using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudio : MonoBehaviour
{
    static bool AudioBegin = false;

    void Awake()
    {
        if (!AudioBegin)
        {
            var audio = GetComponent<AudioSource>();
            audio.Play();
            audio.loop = true;
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
}
