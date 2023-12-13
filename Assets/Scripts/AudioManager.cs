using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, effectsSource, footstepsSource;
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
    
    public void PlayMusic(AudioClip audioClip)
    {
        musicSource.clip = audioClip;
        musicSource.Play();
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
        Debug.Log("master volume is " + value);
    }

    public void ToggleEffects()
    {
        effectsSource.mute = !effectsSource.mute;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void Footsteps(bool state)
    {
        if (state)
        {
            footstepsSource.gameObject.SetActive(true);
        }
        else
        {
            footstepsSource.gameObject.SetActive(false);
        }
        footstepsSource.enabled = state;
    }
    
}
