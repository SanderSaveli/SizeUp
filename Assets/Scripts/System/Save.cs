using System;
using UnityEngine;

[Serializable]
public class Save
{
    private ThemeRepositoryData _themeRepositoryData;
    private FigureRepositoryData _figureRepositoryData;

    public Save()
    {
        CollectThemeRepositoryData();
        CollectFigureRepositoryData();
    }

    [Serializable]
    public struct ThemeRepositoryData
    {
        public int ActiveThemeIndex;
        public bool[] IsThemeOpen;
    }

    [Serializable]
    public struct FigureRepositoryData
    {
        public int ActiveFigureIndex;
    }

    public ThemeRepositoryData GetThemeRepositoryData()
    {
        return _themeRepositoryData;
    }

    public FigureRepositoryData GetFigureRepositoryData()
    {
        return _figureRepositoryData;
    }

    private void CollectThemeRepositoryData()
    {
        ThemeRepository themeRepository = GameObject.FindObjectOfType<ThemeRepository>();
        _themeRepositoryData = new ThemeRepositoryData();
        _themeRepositoryData.ActiveThemeIndex = themeRepository.ActiveThemeIndex;
        _themeRepositoryData.IsThemeOpen = themeRepository.IsThemeOpen;
    }

    private void CollectFigureRepositoryData()
    {
        FigureRepository figureRepository = GameObject.FindObjectOfType<FigureRepository>();
        _figureRepositoryData = new FigureRepositoryData();
        _figureRepositoryData.ActiveFigureIndex = figureRepository.ActiveFigureIndex;
    }
}