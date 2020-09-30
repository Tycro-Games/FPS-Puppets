using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShooting : MonoBehaviour
{
    private AudioSource audio;

    public void Play (AudioClip clip)
    {
        audio.clip = clip;
        Play ();
    }

    public void Play ()
    {
        audio.Play ();
    }

    // Start is called before the first frame update
    private void Start ()
    {
        audio = GetComponent<AudioSource> ();
    }
}