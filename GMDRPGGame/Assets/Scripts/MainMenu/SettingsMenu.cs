using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void setVolume(float setVolume){
        audioMixer.SetFloat("CurrentVolume", setVolume);
    }
    public void setFullScreen(bool bIsFullScreen)
    {
        Screen.fullScreen = bIsFullScreen;
    }

    public void setQuality(int qualityIndex)
    {
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
