using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MainMenu.GraphicSettingsMenu
{
    public class VolumeOption : Option
    {
        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private GameObject slider;
        public override void Apply()
        {
            GraphicSettingHelperMethods.ChangeVolumeSettings(slider.GetComponent<Slider>().value, audioMixer);
        }
        
        public GameObject getSlider(){
            return slider;
        }

        public void IncreaseVolume(){
            
            slider.GetComponent<Slider>().value += 10;
            Apply();
        }

        public void DecreaseVolume(){
            slider.GetComponent<Slider>().value -= 10;
            Apply();
        }

        public void SetCurrentsuboptionByValue(float v)
        {
            slider.GetComponent<Slider>().value = v;
        }
    }
}

