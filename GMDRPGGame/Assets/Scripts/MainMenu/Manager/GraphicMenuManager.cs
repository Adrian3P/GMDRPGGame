using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.GraphicSettingsMenu
{
    [RequireComponent(typeof(GraphicSettingSaveManager))]
    public class GraphicMenuManager : MonoBehaviour
    {
        public ResolutionOption resolutionOption;
        public ScreenmodeOption screenmodeOption;
        public VolumeOption volumeOption;
        public QualityOption qualityOption;
        private GraphicSettingDataContainer dataToSave = new GraphicSettingDataContainer();//Data to be saved will be stored in this 
        private GraphicSettingDataContainer dataToLoad = new GraphicSettingDataContainer();//Data will be loaded into this 
        private GraphicSettingSaveManager graphicSettingSaveManager;        
        private void Start()
        {

            graphicSettingSaveManager = GetComponent<GraphicSettingSaveManager>();

            if(graphicSettingSaveManager.FileExists())
            {
                Load();
                UpdateUIFromLoadedData();
                ApplySettings();
            }
            else
            {
                Save();
            }
            
        }
        public void OnApplyButtonPress()
        {
            ApplySettings();
        }
        private void ApplySettings()
        {
            resolutionOption.Apply();
            screenmodeOption.Apply();
            volumeOption.Apply();
            qualityOption.Apply();
            Save();
        }
        public void Save()
        {
            //Assign values to dataToSave
            dataToSave.screenHeight = (int)resolutionOption.currentSubOption.vector2Value.y;
            dataToSave.screenWidth = (int)resolutionOption.currentSubOption.vector2Value.x;
            dataToSave.volumeLevel = volumeOption.getSlider().GetComponent<Slider>().value;
            dataToSave.screenMode = screenmodeOption.currentSubOption.integerValue;
            dataToSave.qualityLevel = qualityOption.currentSubOption.integerValue;

            graphicSettingSaveManager.SaveSettings(dataToSave);
        }
        public void Load()
        {
            graphicSettingSaveManager.LoadSettings(out dataToLoad);
        }
        private void UpdateUIFromLoadedData()
        {
            //so that the player will see the current settings on the menu
            resolutionOption.SetCurrentsuboptionByValue(new Vector2(dataToLoad.screenWidth, dataToLoad.screenHeight));
            screenmodeOption.SetCurrentsuboptionByValue(dataToLoad.screenMode);
            volumeOption.SetCurrentsuboptionByValue(dataToLoad.volumeLevel);
            qualityOption.SetCurrentsuboptionByValue(dataToLoad.qualityLevel);
        }
    }
}

