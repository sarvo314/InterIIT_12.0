using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic, toggleEffects;
    [SerializeField] private TextMeshProUGUI toggleMusicText, toggleEffectsText;
    
    public void Toggle()
    {
        if (toggleMusic)
        {

            if (AudioManager.Instance.ToggleMusic())
            {
                toggleMusicText.text = "MUSIC: OFF";
            }
            else
            {
                toggleMusicText.text = "MUSIC: ON";
            }
           
        }

        if (toggleEffects)
        {

            if (AudioManager.Instance.ToggleEffects())
            {
                toggleEffectsText.text = "EFFECTS: OFF";
            }
            else
            {
                toggleEffectsText.text = "EFFECTS: ON";
            }
        }
    }
    
}
