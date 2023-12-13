using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    void Start()
    {
        AudioManager.Instance.ChangeMasterVolume(volumeSlider.value);
        volumeSlider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));
    }
}
