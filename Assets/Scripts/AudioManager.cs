using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, effectsSource;
    public static AudioManager Instance;
    
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayAudio(AudioClip audioClip)
    {
        if(PauseMenu.isPaused){
            effectsSource.pitch *= 0.5f;
        }
        else{
            effectsSource.pitch *= 1f;
        }
        effectsSource.PlayOneShot(audioClip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ToggleEffects()
    {
        effectsSource.mute = !effectsSource.mute;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    
}
