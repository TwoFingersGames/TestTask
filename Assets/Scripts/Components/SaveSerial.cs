using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : Game
{
    public SaveData saveData;
    public float[,] rating=new float[2,20];
    public bool restart;
    private void Awake()
    {
        app.saveSerial = gameObject.GetComponent<SaveSerial>();
        Load();
    }

    private void Start()
    {
        saveData = new SaveData();
    }
    private void OnApplicationQuit()
    {
        restart = false;
        Save();
    }

    public void Save()
    {
        //Data
        saveData.rating = rating;
        saveData.restart = restart;
        
        if (!Directory.Exists(Application.persistentDataPath+"/Saves"))
        { 
            Directory.CreateDirectory(Application.persistentDataPath+"/Saves");
            Debug.Log("Create derictory /Saves");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/Saves/save.tt");
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Save file created");
    }
    
    public void Load()
    {
        
        if (File.Exists(Application.persistentDataPath+"/Saves/save.tt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/Saves/save.tt", FileMode.Open);
            saveData = (SaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Data loaded");
            //Data
            rating = saveData.rating;
            restart = saveData.restart;
            
            Debug.Log("File Loaded!");
        }
        else
        {
            //NativeSettings
            restart = false;
            Debug.LogError("File not exist. Load error");
            Save();
            
        }
            
    }
    
    [Serializable]
    public class SaveData
    {
        //Data
        public float[,] rating = new float[2, 20];
        public bool restart;
    }
}
