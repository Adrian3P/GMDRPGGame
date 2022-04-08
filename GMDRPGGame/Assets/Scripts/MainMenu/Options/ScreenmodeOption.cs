using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu.GraphicSettingsMenu
{
    public class ScreenmodeOption : Option
    {
        private void Awake()
        {
            if(currentSubOption.name == "" && subOptionList.Count > 0)
            {
                currentSubOptionIndex = 0;
                currentSubOption = subOptionList[currentSubOptionIndex];
                UpdateSuboptionText();
            }
        }
        public override void Apply()
        {
            GraphicSettingHelperMethods.ChangeScreenMode(currentSubOption.integerValue);
        }

        public void SetCurrentsuboptionByValue(int v)
        {
            if (subOptionList.Count > 0)
            {
                foreach (var t in subOptionList)
                {
                    if (t.integerValue == v)
                    {
                        currentSubOption = t;
                        currentSubOptionIndex = t.indexInList;
                        UpdateSuboptionText();
                        return;
                    }
                }

                Debug.LogWarning("Suboption with value : " + v + " ,not found in :" + gameObject.name + ",using fallback option instead");
                currentSubOption = fallBackOption;
                currentSubOptionIndex = fallBackOption.indexInList;
            }
            else
            {
                Debug.LogError("No items in suboption list : " + gameObject.name);
            }
        }
    }
}

