using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource, effectsSource, footstepsSource;
    public static AudioManager Instance;
    [SerializeField] private Footsteps footsteps;
    
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
    bool canPlayFootsteps = true;
    public void Footsteps(bool state)
    {
        if(state && canPlayFootsteps)
        {
            // footstepsSource.PlayOneShot();
            //Debug.Log("footstoeps started");
            StartCoroutine(footstepCooldown());

        }
        else
        {
            //Debug.Log(("footsteps stopped"));
            // footstepsSource.Stop();
        }
    }
    IEnumerator footstepCooldown()
    {
        canPlayFootsteps = false;
        footstepsSource.PlayOneShot(footsteps.GetFootstep());
        yield return new WaitForSeconds(0.2f);
        canPlayFootsteps = true;
    }
    
}
