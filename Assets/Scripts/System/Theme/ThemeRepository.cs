using Services;
using Services.StorageService;
using System;
using System.IO;
using UnityEngine;
using Singletones;

namespace ViewElements
{
    public class ThemeRepository : DontDestroyOnLoadSingletone<ThemeRepository>
    {
        [field: SerializeField] public ThemeDatabase database { get; private set; }
        private ThemeDatabase _database;
        [field: SerializeField] public int activeThemeIndex { get; private set; }
        [field: SerializeField] public bool[] isThemeOpen { get; private set; }

        public Theme acktiveTheme { get; private set; }

        private string saveKey = "ThemeRepository";

        [Serializable]
        public struct ThemeRepositoryData
        {
            public int activeThemeIndex;
            public bool[] isThemeOpen;
        }

        private void Awake()
        {
            base.Awake();
            acktiveTheme = database.themes[activeThemeIndex];
        }

        public Theme GetActiveTheme()
        {
            return acktiveTheme;
        }

        public ButtonTheme GetActiveButtonTheme()
        {
            return GetActiveTheme().ButtonTheme;
        }

        public BackgroundTheme GetActiveBackGroundTheme()
        {
            return GetActiveTheme().BackgroundTheme;
        }

        public PlayerTheme GetActivePlayerTheme()
        {
            return GetActiveTheme().PlayerTheme;
        }

        public EnemyTheme GetActiveEnemyTheme()
        {
            return GetActiveTheme().EnemyTheme;
        }

        public void SaveData()
        {
            ThemeRepositoryData currentData = new ThemeRepositoryData();
            currentData.activeThemeIndex = activeThemeIndex;
            currentData.isThemeOpen = isThemeOpen;
            ServiceLockator.instance.GetService<IStoregeService>().Save(saveKey, currentData);

        }
        public void LoadData()
        {
            try 
            {
                ServiceLockator.instance.GetService<IStoregeService>().Load<ThemeRepositoryData>(saveKey, IniRepository);
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

        private void IniRepository(ThemeRepositoryData data)
        {
            activeThemeIndex = data.activeThemeIndex;
            isThemeOpen = data.isThemeOpen;
        }
    }

}
