using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void setVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
    }
}
