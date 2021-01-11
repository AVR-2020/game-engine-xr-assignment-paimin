using UnityEngine.Audio;
using UnityEngine;
using System.Media;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private void Awake()
    {
        foreach (Sound s in sounds )
        {
            s.setSource(gameObject.AddComponent<AudioSource>(), s.getClip(), s.getVolume(), s.getPitch());
        }
    }

    public void Play (string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.getName() == name)
            {
                s.getSource().Play();
            }
        }
    }
}
