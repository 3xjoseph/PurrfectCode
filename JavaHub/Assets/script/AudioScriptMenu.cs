using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScriptMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateAudioVolume);
    }

    private void UpdateAudioVolume(float value)
    {
        audioSource.volume = value;
    }
}
