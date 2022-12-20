using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private SaveLoadSystem loadSystem;

    private ThemeRepository themeRepository;
    private FigureRepository figureRepository;

    private void Awake()
    {
        Initialize();
        LoadDataToRepository();
    }

    private void Initialize()
    {
        loadSystem = new SaveLoadSystem();
        themeRepository = FindObjectOfType<ThemeRepository>();
        figureRepository = FindObjectOfType<FigureRepository>();
    }

    private void LoadDataToRepository() 
    { 
        Save save = loadSystem.GetCurrentSave();
        themeRepository.loadData(save.GetThemeRepositoryData());
        figureRepository.LoadData(save.GetFigureRepositoryData());
    } 

}
