using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadSystem
{
    private Save currentSave;
    private string _saveFilePath;

    public SaveLoadSystem() 
    {
        _saveFilePath = Application.persistentDataPath + "/Save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_saveFilePath, FileMode.Create);

        Save save = new Save();
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(_saveFilePath))
            return;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_saveFilePath, FileMode.Open);

        Save save = (Save)binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
        currentSave = save;
    }

    public Save GetCurrentSave()
    {
        return currentSave;
    }
}
