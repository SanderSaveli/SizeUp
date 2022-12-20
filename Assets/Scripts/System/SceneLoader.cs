using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private SaveLoadSystem loadSystem;

    public ThemeRepository themeRepository;
    public FigureRepository figureRepository;

    public ThemeInitializer themeInitializer;

    private void Awake()
    {
        Initialize();
        LoadDataToRepository();
        PaintAllToThemeColor();
    }

    private void Initialize()
    {
        loadSystem = new SaveLoadSystem();
        //themeRepository = FindObjectOfType<ThemeRepository>();
        //figureRepository = FindObjectOfType<FigureRepository>();
        //themeInitializer = FindObjectOfType<ThemeInitializer>();
    }

    private void LoadDataToRepository() 
    { 
        Save save = loadSystem.GetCurrentSave();
        themeRepository.loadData(save.GetThemeRepositoryData());
        figureRepository.LoadData(save.GetFigureRepositoryData());
    } 

    private void PaintAllToThemeColor() 
    {
        themeInitializer.IniThemeOnObjects(
            themeRepository.GetActiveTheme()
            );
    }

}
