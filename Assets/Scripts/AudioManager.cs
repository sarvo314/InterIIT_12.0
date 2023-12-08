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
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayAudio(AudioClip audioClip)
    {
        effectsSource.PlayOneShot(audioClip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
