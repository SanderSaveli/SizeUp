using Services;
using Services.StorageService;
using System;
using System.IO;
using UnityEngine;
using Singletones;

public class FigureRepository : Singletone<FigureRepository>
{
    [field: SerializeField] public GameObject[] figures { get; private set; }
    [field: SerializeField] public int activeFigureIndex { get; private set; }
    [field: SerializeField] public bool[] isFigureOpen { get; private set; }

    private string saveKey = "FigureReposirory";
    [Serializable]
    public struct FigureRepositoryData
    {
        public int activeFigureIndex;
        public bool[] isFigureOpen;
    }

    public GameObject GetActiveFigure()
    {
        return figures[activeFigureIndex];
    }
    public void SaveData()
    {
        FigureRepositoryData currentData = new FigureRepositoryData();
        currentData.activeFigureIndex = activeFigureIndex;
        currentData.isFigureOpen = isFigureOpen;
        ServiceLockator.instance.GetService<IStoregeService>().Save(saveKey, currentData);

    }
    public void LoadData()
    {
        try 
        {
                ServiceLockator.instance.GetService<IStoregeService>().CallbackLoad<FigureRepositoryData>(saveKey, IniRepository);
        }
        catch (FileNotFoundException) 
        {
            CreateFirstSave();
            LoadData();
        }
    }

    private void CreateFirstSave()
    {
        SaveData();
    }

    private void IniRepository(FigureRepositoryData data)
    {
        activeFigureIndex = data.activeFigureIndex;
        isFigureOpen = data.isFigureOpen;
    }
}
