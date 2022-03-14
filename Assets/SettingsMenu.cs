using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Rendering;



public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionsDropdown;

    // public RenderPipelineAsset[] qualityLevels;
    // public TMP_Dropdown dropdown;

    Resolution[] resolutions;

    void Start()
    {
        // dropdown.value = QualitySettings.GetQualityLevel();

        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        int currResInd = 0;
        List<string> options = new List<string>();

        for (int i=0;i<resolutions.Length;i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                currResInd = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currResInd;
        resolutionsDropdown.RefreshShownValue();
    }

    public void setFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("masterVol",volume);
    }

    public void setResolution ( int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // public void setQuality(int value)
    // {
    //     Debug.Log(value);
    //     QualitySettings.SetQualityLevel(value);
    //     QualitySettings.renderPipeline = qualityLevels[value];

    // }
}
