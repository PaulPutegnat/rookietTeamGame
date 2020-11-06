using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerT1 : MonoBehaviour
{
    public SoundT1[] sounds;

    void Start()
    {

    }
    void Awake()
    {
        foreach (SoundT1 s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        SoundT1 s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        SoundT1 s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}