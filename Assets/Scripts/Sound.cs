using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    [SerializeField] private AudioClip clip;
    [Range(0f, 1f)] [SerializeField] private float volume;
    [Range(.1f, 3f)] [SerializeField] private float pitch;
    private AudioSource source;

    public float getVolume()
    {
        return volume;
    }

    public AudioClip getClip()
    {
        return clip;
    }

    public float getPitch()
    {
        return pitch;
    }

    public string getName()
    {
        return name;
    }

    public AudioSource getSource()
    {
        return source;
    }

    public void setSource(AudioSource anything, AudioClip clips, float vol, float pic)
    {
        source = anything;
        source.clip = clips;
        source.volume = vol;
        source.pitch = pic;
    }
}
