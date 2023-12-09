using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame : MonoBehaviour
{
    public static DataGame instance;

    public DataClass dataClass;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Load();
        }

    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void Save()
    {
        string filePath = Application.persistentDataPath + "/GameData.jhon";
        string data = JsonUtility.ToJson(dataClass);
        System.IO.File.WriteAllText(filePath, data);

        print("Data berhasil di simpan di : " + filePath);

    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/GameData.jhon";

        if (System.IO.File.Exists(filePath))
        {
            string data = System.IO.File.ReadAllText(filePath);

            dataClass = JsonUtility.FromJson<DataClass>(data);
        }
        // Data default
        else
        {
            dataClass.levels[1] = true;

            dataClass.volumeBGM = 0.5f;
            dataClass.volumeSFX = 0.8f;
        }

    }

    public void SetLevelComplete()
    {
        if (dataClass.levelIndex < dataClass.levels.Length - 1)
        {
            dataClass.levels[dataClass.levelIndex + 1] = true;
        }
    }
}

[System.Serializable]
public class DataClass
{
    public int levelIndex;
    public bool[] levels = new bool[4];

    public float volumeBGM;
    public float volumeSFX;

    public bool useTutorial;
}
