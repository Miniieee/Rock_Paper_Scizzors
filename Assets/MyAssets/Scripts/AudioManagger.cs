using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManagger : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = s.mixerGroup;
            s.source.clip = s.clip;
            s.source.loop = false;
            s.source.volume = s.volume;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void MuteButtonclickSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 0f;
        
    }

    public void MaxButtonclickSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = 1f;
    }
}
