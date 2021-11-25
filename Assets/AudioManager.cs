using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [HideInInspector] public AudioSource source;
    public AudioClip sound;

    void Awake() 
    {
        source= gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.loop = true;
    }

    public void Play()
    { 
        source.Play();
    }


void Start()
{
        Play();
}

}
