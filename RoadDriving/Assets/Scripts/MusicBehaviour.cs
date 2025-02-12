using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBehaviour : MonoBehaviour
{
    public AudioSource EngineSound;
    private AudioSource audioSource;
    private float defaultVolume;
    private float defaultEngineVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        defaultVolume = audioSource.volume;

        defaultEngineVolume = EngineSound.volume;
    }

    void Update()
    {
        if (GameBehaviour.isGameStarted)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0.2f, Time.deltaTime);
            EngineSound.volume = Mathf.Lerp(EngineSound.volume, 0.6f, Time.deltaTime);
        } else {
            audioSource.volume = Mathf.Lerp(audioSource.volume, defaultVolume, Time.deltaTime);
            EngineSound.volume = Mathf.Lerp(EngineSound.volume, defaultEngineVolume, Time.deltaTime);
        }
    }
}
