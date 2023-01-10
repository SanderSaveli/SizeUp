using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ThemeRepository : MonoBehaviour
{ 
    public Theme[] Themes;
    public int ActiveThemeIndex;
    public bool[] IsThemeOpen;

    public Theme GetActiveTheme() 
    { 
        return Themes[ActiveThemeIndex];
    }
    public void loadData(Save.ThemeRepositoryData data) 
    {
        this.ActiveThemeIndex = data.ActiveThemeIndex;
        this.IsThemeOpen = data.IsThemeOpen;
    }
}
