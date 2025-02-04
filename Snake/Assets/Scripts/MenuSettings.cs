using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    bool isFullScreen = false;

    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown Dropdown;
    public void FullSceenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }


    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;

        foreach (var i in rsl)
            resolutions.Add(i.width + "x" + i.height);

        Dropdown.ClearOptions();
        Dropdown.AddOptions(resolutions);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}