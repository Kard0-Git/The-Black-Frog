using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public SoundClass[] sounds;

    void Awake()
    {
        foreach(SoundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loopSound;
            s.source.pitch = s.pitch;
        }
    }
    public void PlaySounds(string name)
    {
        SoundClass specific_sounds = Array.Find(sounds, sound => sound.name == name);
        specific_sounds.source.Play();
    }
}
