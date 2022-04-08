using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MainMenu.GraphicSettingsMenu
{
    public static class GraphicSettingHelperMethods
    {
        public static void ChangeScreenMode(int screenMode)
        {
            Screen.fullScreenMode = (FullScreenMode)screenMode;
        }
        public static void ChangeResolution(int x, int y)
        {
            Screen.SetResolution(x, y, Screen.fullScreenMode);
        }
        public static void ChangeQualitySettings(int qualityLevelIndex)
        {
            QualitySettings.SetQualityLevel(qualityLevelIndex);
        }
        public static void ChangeVolumeSettings(float setVolume, AudioMixer audioMixer){
            audioMixer.SetFloat("CurrentVolume", setVolume);
        }
    }
}

