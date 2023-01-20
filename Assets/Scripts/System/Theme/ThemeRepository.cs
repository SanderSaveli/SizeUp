using System;
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
    public ButtonTheme GetActiveButtonTheme() 
    {
        return Themes[ActiveThemeIndex].ButtonTheme;
    }

    public BackgroundTheme GetActiveBackGroundTheme()
    {
        return Themes[ActiveThemeIndex].BackgroundTheme;
    }

    public PlayerTheme GetActivePlayerTheme()
    {
        return Themes[ActiveThemeIndex].PlayerTheme;
    }

    public EnemyTheme GetActiveEnemyTheme() 
    {
        return Themes[ActiveThemeIndex].EnemyTheme;
    }

    public void loadData(Save.ThemeRepositoryData data)
    {
        this.ActiveThemeIndex = data.ActiveThemeIndex;
        this.IsThemeOpen = data.IsThemeOpen;
    }
}
