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

            dataClass.volumeBGM = 0.5f;
            dataClass.volumeSFX = 0.8f;
        }

    }

    public void AddHighLevel(float value)
    {
        if (value > dataClass.highLevel)
        {
            dataClass.highLevel = value;
        }
    }
}

[System.Serializable]
public class DataClass
{
    public float highLevel;

    public float volumeBGM;
    public float volumeSFX;

    public bool useTutorial;
}
