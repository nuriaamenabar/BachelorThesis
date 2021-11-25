using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [HideInInspector] public AudioSource source;
    public AudioClip sound;
    private float time = 0.0f;
    public float interpolationPeriod = 10f;

    void Awake() 
    {
        source= gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.loop = false;
    }

    public void Play()
    { 
        source.Play();
    }


    void Start()
    {
        Play();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            Play();

        }
    }



}
